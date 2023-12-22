using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class DatTourDto
    {
        public int DatTourId { get; set; }
        public int NguoiDungId { get; set; }
        public int TourId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
