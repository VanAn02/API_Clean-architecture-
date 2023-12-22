using System.ComponentModel.DataAnnotations;

namespace Shop.Api.Controllers.NguoiDung
{
    public class RegisterModel
    {
        public string HoVaTen { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
