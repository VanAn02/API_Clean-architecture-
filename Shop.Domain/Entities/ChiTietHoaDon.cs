using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class ChiTietHoaDon
    {
        public int ChiTietHoaDontId { get; set; }
        public int HoaDonId { get; set; }
        public int TourId { get; set; }
        public int SoLuong { get; set; }
        public string Gia { get; set; }
        public HoaDon? HoaDon { get; set; }
        public Tour? Tour { get; set; } 
    }
}
