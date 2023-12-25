using CloudinaryDotNet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Api.Controllers.NguoiDung;
using Shop.Api.Service;
using Shop.Applicationn.Dto;
using Shop.Applicationn.Services;
using Shop.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Api.Controllers.NguoiDungController
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        public readonly INguoiDungService _nguoiDungService;
        public readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;
        public NguoiDungController(INguoiDungService nguoiDungService, Cloudinary cloudinary, IConfiguration configuration)
        {
            _nguoiDungService = nguoiDungService;
            _cloudinary = cloudinary;
            _configuration = configuration;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingUser = _nguoiDungService.GetAll().FirstOrDefault(x => x.Email == model.Email);
                if (existingUser != null)
                {
                    return BadRequest("Email đã tồn tại");
                }
                else
                {
                    HashMD5 md = new HashMD5();
                    var dto = new NguoiDungDto()
                    {
                        Email = model.Email,
                        HoVaTen = model.HoVaTen,
                        //Password = md.GetMD5(model.Password),
                        Password = model.Password,
                        Quyen = "Người dùng",
                        DiaChi="",
                        NguoiDungHinhAnh="",
                        Sdt = "",
                        NguoiDungId = 0
                    };
                    _nguoiDungService.Create(dto);
                    return Ok("đăng ky thành công");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nguoiDungService.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_nguoiDungService.Get(id));
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            HashMD5 md = new HashMD5();
            var user = _nguoiDungService.GetAll().Find(x => x.Email == model.Email && x.Password == model.Password);

            if (user != null)
            {
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,string.Join(",",user.Quyen)),
                    new Claim(ClaimTypes.NameIdentifier,user.NguoiDungId.ToString()),
                };
                var token = new JwtSecurityToken(
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredential,
                        claims: claims
                    );
                return Ok(new
                {
                    message = "Đăng nhập thành công",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    quyen=user.Quyen
                });
            }
            return BadRequest("Tài khoản hoặc mật khẩu không chính xác");
        }
        [HttpPost("forgot")]
        public IActionResult Forgot([FromBody] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Chưa nhập thông tin");
                }
                else
                {
                    var existingUser = _nguoiDungService.GetAll().FirstOrDefault(x => x.Email == email);
                    if (existingUser != null)
                    {
                        RandomPassword rd = new RandomPassword();
                        var code = rd.GenerateCode();
                        HashMD5 md = new HashMD5();

                        var dto = new NguoiDungDto()
                        {
                            NguoiDungId = existingUser.NguoiDungId,
                            HoVaTen = existingUser.HoVaTen,
                            NguoiDungHinhAnh = existingUser.HoVaTen,
                            Email = existingUser.Email,
                            Password = md.GetMD5(code),
                            DiaChi = existingUser.DiaChi,
                            Sdt = existingUser.Sdt,
                            Quyen = existingUser.Quyen

                        };

                        var registrationResult = _nguoiDungService.Update(dto);

                        if (registrationResult)
                        {
                            string subject = "Xác nhận quên mật khẩu tài khoản";
                            string message = $"<p>Đây là mật khẩu mới của bạn: {code}</p>";

                            //_emailService.SendEmail(email, subject, message);

                            return Ok("Vui lòng kiểm tra email để lấy mật khẩu mới và đăng nhập.");
                        }
                        else
                        {
                            return BadRequest("Vui lòng thử lại sau.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Đã xảy ra lỗi trong quá trình xử lý.");
            }
            return BadRequest("Đã xảy ra lỗi không xác định.");
        }

        [HttpPost("DecodeToken")]
        public IActionResult Token(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var Token = (JwtSecurityToken)validatedToken;

                var nguoidungId = Token.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var quyen = Token.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                var response = new
                {
                    NguoiDungId = nguoidungId,
                    Quyen = quyen,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Token validation failed: {ex.Message}");
            }
        }
        [HttpPut("updateUser/{id}")]
        public IActionResult updateUser([FromForm] NguoiDungModel model)
        {
            var url = _nguoiDungService.Get(model.NguoiDungId).NguoiDungHinhAnh;
            UpLoadImage upload = new UpLoadImage(_cloudinary);
            var dto = new NguoiDungDto();
            dto.NguoiDungId = model.NguoiDungId;
            dto.HoVaTen = model.HoVaTen;
            dto.Email = model.Email;
            dto.Password = model.Password;
            dto.DiaChi = model.DiaChi;
            dto.Sdt = model.Sdt;
            dto.Quyen = model.Quyen;
            if (model.NguoiDungHinhAnh != null)
            {
                if (url != null)
                {
                    dto.NguoiDungHinhAnh = upload.ImageUpload(model.NguoiDungHinhAnh);
                }
                else
                {
                    dto.NguoiDungHinhAnh = upload.ImageUpload(model.NguoiDungHinhAnh);
                }
            }
            else
            {
                dto.NguoiDungHinhAnh = url;
            }
            if (_nguoiDungService.Update(dto))
            {
                return Ok("Cập nhật thông tin thành công");
            }
            return BadRequest("Lỗi không thể thao tác");
            
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromForm] NguoiDungModel model)
        {
            UpLoadImage upload = new UpLoadImage(_cloudinary);

            var dto = new NguoiDungDto()
            {
                DiaChi = model.DiaChi,
                Email = model.Email,
                HoVaTen = model.HoVaTen,
                NguoiDungHinhAnh = upload.ImageUpload(model.NguoiDungHinhAnh),
                Password= model.Password,
                Quyen= model.Quyen,
                Sdt= model.Sdt,
            };
            if (_nguoiDungService.Create(dto))
            {
                return Ok("Thêm người dùng thành công");
            }
            return BadRequest("Lỗi không thể thao tác");

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_nguoiDungService.Delete(id))
            {
                return Ok("Xóa thành công");
            }
            return NotFound("Không thể xóa vì người dùng này không tồn tại");
        }
    }
}
