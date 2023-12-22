using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class DatTour
    {
        public int DatTourId { get; set; }
        public int NguoiDungId { get; set; }
        public int TourId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
