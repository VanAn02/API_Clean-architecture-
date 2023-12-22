namespace Shop.Api.Controllers.NguoiDung
{
    public class NguoiDungModel
    {
        public int NguoiDungId { get; set; }
        public IFormFile? NguoiDungHinhAnh { get; set; }
        public string? HoVaTen { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? Quyen { get; set; }
    }
}
