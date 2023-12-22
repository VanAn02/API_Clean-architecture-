using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Controllers.Tour;
using Shop.Api.Service;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;
using Shop.Domain.Entities;

namespace Shop.Api.Controllers.BaiVietController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly IBaiVietService _baivietService;
        private readonly Cloudinary _cloudinary;
        public BaiVietController(IBaiVietService baivietService, Cloudinary cloudinary)
        {
            _baivietService = baivietService;
            _cloudinary = cloudinary;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_baivietService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetBaiViet(int id)
        {
            var baiviet = _baivietService.Get(id);
            if (baiviet == null)
            {
                return NotFound();
            }
            return Ok(baiviet);
        }
        [HttpPost]
        public IActionResult AddBaiViet([FromForm] BaiVietModel model)
            {
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new BaiVietDto()
            {
                TieuDe = model.TieuDe,
                NoiDung = model.NoiDung,
                AnhBaiViet = upload.ImageUpload(model.AnhBaiViet),
                NgayDang = DateTime.Now,
                NguoiDungId = model.NguoiDungId,
               
            };

            if (_baivietService.Add(dto))
            {
                return CreatedAtAction("GetBaiViet", new { id = dto.BaiVietId }, dto);
            }
            return Ok("BaiViet đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBaiViet([FromForm] BaiVietModel model)
        {
            var url = _baivietService.Get(model.BaiVietId).AnhBaiViet;
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new BaiVietDto();
            dto.TieuDe = model.TieuDe;
            dto.NoiDung = model.NoiDung;
            dto.NgayDang = DateTime.Now;
            dto.NguoiDungId = model.NguoiDungId;
            dto.BaiVietId = model.BaiVietId;
            if (model.AnhBaiViet == null)
            {
                dto.AnhBaiViet = url;
            }
            else
            {
                dto.AnhBaiViet = upload.ImageUpload(model.AnhBaiViet);
            }
            if (_baivietService.Update(dto))
            {
                return Ok(new { message = "Cập nhật thành công" });
            }
            return BadRequest("Không thể thực hiện thao tác này");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBaiViet(int id)
        {
            if (_baivietService.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Không thể xóa vì BaiViet này không tồn tại");
        }
    }
}
