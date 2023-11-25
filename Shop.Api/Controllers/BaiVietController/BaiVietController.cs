using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public BaiVietController(IBaiVietService baivietService)
        {
            _baivietService = baivietService;
        }
        [HttpGet]
        public IActionResult GetBaiViets()
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
        public IActionResult PostBaiViet(BaiVietDto baiviet)
        {
            if (_baivietService.Add(baiviet))
            {
                return CreatedAtAction("GetBaiViet", new { id = baiviet.Id }, baiviet);
            }
            return Ok("Danh mục bài viết đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult PutBaiViet(BaiVietDto baiviet)
        {
            if (_baivietService.Update(baiviet))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBaiViet(int id)
        {
            if (_baivietService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì bài viết này không tồn tại");
        }
    }
}
