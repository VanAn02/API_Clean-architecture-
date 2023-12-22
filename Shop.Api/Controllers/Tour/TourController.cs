using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Controllers.Tour;
using Shop.Api.Service;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;
using Shop.Domain.Entities;

namespace Shop.Api.Controllers.TourController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly Cloudinary _cloudinary;
        public TourController(ITourService tourService,Cloudinary cloudinary)
        {
            _tourService = tourService;
            _cloudinary = cloudinary;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_tourService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetTour(int id)
        {
            var tour = _tourService.Get(id);
            if (tour == null)
            {
                return NotFound();
            }
            return Ok(tour);
        }
        [HttpPost]
        public IActionResult AddTour([FromForm] TourModel model)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new TourDto() 
            { 
                AnhTour=upload.ImageUpload(model.AnhTour),
                Gia=model.Gia,
                KhoiHanh=model.KhoiHanh,
                KhuVuc=model.KhuVuc,
                MoTa= model.MoTa,
                PhuongTien=model.PhuongTien,
                TenTour=model.TenTour,
                ThoiGian=model.ThoiGian,    
                KhachSan=model.KhachSan,
            };
            
            if (_tourService.Add(dto))
            {
                return CreatedAtAction("GetTour", new { id = dto.TourId }, dto);
            }
            return Ok("Tour đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTour([FromForm] TourModel model)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var urlImg = "";
            if (_tourService.GetAll().Where(x => x.TourId == model.TourId).FirstOrDefault() != null)
            urlImg = _tourService.GetAll().Where(x => x.TourId == model.TourId).FirstOrDefault().AnhTour;
            var dto = new TourDto();
            dto.KhuVuc = model.KhuVuc;
            dto.MoTa = model.MoTa;
            dto.TourId = model.TourId;
            dto.TenTour = model.TenTour;
            dto.PhuongTien = model.PhuongTien;
            dto.ThoiGian = model.ThoiGian;
            dto.KhoiHanh = model.KhoiHanh;
            dto.KhachSan=model.KhachSan;
            dto.Gia = model.Gia;
            if (model.AnhTour != null)
            {
                dto.AnhTour = upload.ImageUpload(model.AnhTour);
            }
            else
            {
                dto.AnhTour = urlImg;
            }
            if (_tourService.Update(dto))
            {
                return Ok(new { message = "Cập nhật thông tin thành công" });
            }
            return BadRequest("Không thể thực hiện thao tác này");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTour(int id)
        {
            if (_tourService.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Không thể xóa vì tour này không tồn tại");
        }
    }
}
