namespace Shop.Api.Controllers.BaiVietController
{
    public class BaiVietModel
    {
        public int BaiVietId { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung {  get; set; }
        public IFormFile? AnhBaiViet { get; set; }
        public DateTime NgayDang { get; set; }
        public int NguoiDungId { get; set; }
    }
}
