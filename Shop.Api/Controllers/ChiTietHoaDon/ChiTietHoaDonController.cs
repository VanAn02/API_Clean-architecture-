using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers.ChiTietHoaDon
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("OK");
        }
    }
}
