using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shop.Api.Controllers.DatTour;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;

namespace Shop.Api.Controllers.DatTourController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatTourController : ControllerBase
    {
        private readonly IDatTourService _datTourService;
        public DatTourController(IDatTourService datTourService)
        {
            _datTourService = datTourService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_datTourService.GetAll());
        }
        [HttpPost]
        public IActionResult Add(DatTourDto datTourDto)
        {
            if (_datTourService.Add(datTourDto))
            {
                return Ok("Đặt thành công");
            }
            return BadRequest("Lỗi không thể thao tác");
        }
    }
}
