using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }
        [HttpGet]
        public IActionResult GetCategories()
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
        public IActionResult PostTour(TourDto tour)
        {
            if (_tourService.Add(tour))
            {
                return CreatedAtAction("GetTour", new { id = tour.Id }, tour);
            }
            return Ok("Danh mục tour đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult PutTour(TourDto tour)
        {
            if (_tourService.Update(tour))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTour(int id)
        {
            if (_tourService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì tour này không tồn tại");
        }
    }
}
