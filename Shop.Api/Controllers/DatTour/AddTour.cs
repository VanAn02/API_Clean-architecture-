using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Shop.Api.Controllers.DatTour
{
    public class AddTour
    {
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public int NguoiDungId { get; set; }
        public int TourId { get; set; }
    }
}
