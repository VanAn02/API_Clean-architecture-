﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string TenTour { get; set; }
        public string AnhTour { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
        public string DiaDiem { get; set; }
        public string KhuVuc { get; set; }
        public string ThoiGian { get; set; }
        public string KhoiHanh { get; set; }
        public string PhuongTien { get; set; }
        public virtual ICollection<DatTour> DatTours { get; set; }
    }   
}
