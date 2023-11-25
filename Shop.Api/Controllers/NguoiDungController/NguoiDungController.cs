using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Api.Controllers.NguoiDungController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDungService _nguoidungService;
        private readonly IConfiguration _configuration;
        public NguoiDungController(INguoiDungService nguoidungService, IConfiguration configuration)
        {
            _nguoidungService = nguoidungService;
            _configuration = configuration;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] NguoiDungDto nguoidungDto)
        {
            var user = _nguoidungService.GetAll().Where(x => x.TenDangNhap.Equals(nguoidungDto.TenDangNhap) && x.MatKhau == nguoidungDto.MatKhau).FirstOrDefault();
            if (user != null)
            {
                //lấy khóa bí mật trong file appsetting.json
                //mã hóa khóa bí mật
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                //ký vào khóa bí mật đã mã hóa
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                //tạo ra claims để chứ thông tin bổ sung
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Name,nguoidungDto.TenDangNhap),
                    new Claim(ClaimTypes.Email,nguoidungDto.Email)
                };
                //tạo token vs các thông số khớp với cấu hình trong file programs để validate
                var token = new JwtSecurityToken
                (
                      issuer: _configuration["Jwt:Issuer"],
                      audience: _configuration["Jwt:Audience"],
                      expires: DateTime.Now.AddMinutes(5),
                      signingCredentials: signingCredential,
                      claims: claims
                );
                // sinh ra chuỗi token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nguoidungService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var nguoidung = _nguoidungService.Get(id);
            if (nguoidung == null)
            {
                return NotFound();
            }
            return Ok(nguoidung);
        }
        [HttpPost]
        public IActionResult Post(NguoiDungDto nguoidung)
        {
            if (_nguoidungService.Add(nguoidung))
            {
                return CreatedAtAction("Getnguoidung", new { id = nguoidung.Id }, nguoidung);
            }
            return Ok("Danh mục sản phẩm đã tồn tại");
        }
        [HttpPut("{id}")]
        public IActionResult Put(NguoiDungDto nguoidung)
        {
            if (_nguoidungService.Update(nguoidung))
            {
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_nguoidungService.Delete(id))
            {
                return NoContent();
            }
            return NotFound("Không thể xóa vì loại sản phẩm này không tồn tại");
        }
    }
}
