using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;

namespace Shop.Api.Controllers.DatTourController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatTourController : ControllerBase
    {
        private readonly DatTourService _dattourService;
        public DatTourController(DatTourService dattourService)
        {
            _dattourService = dattourService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dattourService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var dattour = _dattourService.Get(id);
            if (dattour == null)
            {
                return NotFound();
            }
            return Ok(dattour);
        }
        [HttpPost]
        public IActionResult Post(DatTourDto dattour)
        {
            if (_dattourService.Add(dattour))
            {
                return CreatedAtAction("Getdattour", new { id = dattour.TourId }, dattour);
            }
            return Ok("Danh mục đặt tour đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Put(DatTourDto dattour)
        {
            if (_dattourService.Update(dattour))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_dattourService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì đặt tour này không tồn tại");
        }
    }
}
