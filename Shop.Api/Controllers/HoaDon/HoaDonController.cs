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
        private readonly IChiTietHoaDonService _chiTietHoaDonService;
        private readonly IDatTourService _datTourService;
        public HoaDonController(IHoaDonService hoaDonService, IDatTourService datTourService, IChiTietHoaDonService chiTietHoaDonService)
        {
            _hoaDonService = hoaDonService;
            _datTourService = datTourService;
            _chiTietHoaDonService = chiTietHoaDonService;
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
    }
}
