using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Services;
using Shop.Infrastructure.Repositories;

namespace Shop.Api.Controllers.ChiTietHoaDon
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : Controller
    {
        private IChiTietHoaDonService repo;
        public ChiTietHoaDonController(IChiTietHoaDonService rPO)
        {
            this.repo=rPO;
        }
        [HttpGet]
        public IActionResult GetByIdHoDon(int id)
        {
            return Ok(repo.GetByIdHoaDon(id));

        }
    }
}
