using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;

namespace Shop.Api.Controllers.HoaDon
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        public readonly IHoaDonService _hoaDonService;
        public readonly ITourService _ITourService;
        private readonly IChiTietHoaDonService _chiTietHoaDonService;
        private readonly IDatTourService _datTourService;
        public HoaDonController(IHoaDonService hoaDonService, IDatTourService datTourService, IChiTietHoaDonService chiTietHoaDonService, ITourService ITourService)
        {
            _hoaDonService = hoaDonService;
            _datTourService = datTourService;
            _chiTietHoaDonService = chiTietHoaDonService;
            _ITourService = ITourService;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            return Ok(_hoaDonService.GetAll());
        }
        /*[HttpPost]
        public IActionResult Add(HoaDonDto dto)
        {
            var datTour = _datTourService.GetdattourById(dto.NguoiDungId);
            if (datTour.Count > 0)
            {
                _hoaDonService.Add(dto);
                var idhoadon = _hoaDonService.GetAll().LastOrDefault(dto).HoaDonId;
                SaveChiTietDonHang(idhoadon, datTour);
                _datTourService.removeDatTourById(dto.NguoiDungId);
                return Ok("Thanh toán thành công");
            }
            return BadRequest("Không thể thao tác");

        }*/
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_hoaDonService.Get(id));
        }
        [NonAction]
        public void SaveChiTietDonHang(int id, List<DatTourDto> dattours)
        {
            foreach (var dattour in dattours)
            {
                var chitiet = new ChiTietHoaDonDto()
                {
                    HoaDonId = id,
                    //DatTourId = dattour.DatTouId,
                    SoLuong = dattour.SoLuong
                };
                _chiTietHoaDonService.Add(chitiet);
            }
        }
        [HttpGet("getChiTiet/{id}")]
        public IActionResult getChiTiet(int id)
        {
            return Ok(_chiTietHoaDonService.Get(id));
        }
        [HttpPost]
        public IActionResult post(HoaDonModel hoaDon)
        {
            var gia = 0;
            var test = _ITourService.GetAll().Where(x => x.TourId == hoaDon.TourId).FirstOrDefault();
            if (_ITourService.GetAll().Where(x => x.TourId == hoaDon.TourId).FirstOrDefault() != null)
            {
                gia = Int32.Parse(_ITourService.GetAll().Where(x => x.TourId == hoaDon.TourId).FirstOrDefault().Gia);
            }
            var tong = (gia * hoaDon.SoLuong).ToString();
            var dto = new HoaDonDto()
            {
                DiaChi = hoaDon.DiaChi,
                GhiChu = hoaDon.GhiChu,
                HoaDonId = 0,
                HoaDonSdt = hoaDon.HoaDonSdt,
                HoVaTen = hoaDon.HoVaTen,
                NgayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                NguoiDungId = hoaDon.NguoiDungId,
                TongTien = tong
            };
            if (_hoaDonService.Add(dto))
            {
                var dtochitiet = new ChiTietHoaDonDto
                {
                    SoLuong = hoaDon.SoLuong,
                    ChiTietHoaDontId = 0,
                    Gia=gia.ToString(),
                    HoaDonId = _hoaDonService.GetAll().Max(x=>x.HoaDonId),
                    TourId = hoaDon.TourId
                };
                if (_chiTietHoaDonService.Add(dtochitiet))
                {
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        /*[HttpDelete("{id}")]
        public IActionResult HuyDon(int id)
        {
            if (_chiTietHoaDonService.removeChiTietHoaDonByIdHoaDon(id))
            {
                _hoaDonService.Delete(id);
                return Ok("Hủy đơn hàng thành công");
            }
            return BadRequest("Không thể thực hiện thao tác");
        }*/
        [HttpGet("getById/{id}")]
        public IActionResult getByIds(int id)
        {
            return Ok(_hoaDonService.GetById(id));
        }
        [HttpPut("{id}")]
        public IActionResult Duyet(HoaDonDto dto)
        {
            return Ok(_hoaDonService.Update(dto));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_hoaDonService.Delete(id));
        }
    }
}
