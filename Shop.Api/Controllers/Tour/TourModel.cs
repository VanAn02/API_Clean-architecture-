namespace Shop.Api.Controllers.Tour
{
    public class TourModel
    {
        public int TourId { get; set; }
        public string TenTour { get; set; }
        public IFormFile? AnhTour { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
        public string KhuVuc { get; set; }
        public string ThoiGian { get; set; }
        public string KhoiHanh { get; set; }
        public string PhuongTien { get; set; }
        public string KhachSan { get; set; }

    }
}
