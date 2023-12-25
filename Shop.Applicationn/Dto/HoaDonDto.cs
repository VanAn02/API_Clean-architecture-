using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class HoaDonDto
    {
        public int HoaDonId { get; set; }
        public int NguoiDungId { get; set; }
        public string TongTien { get; set; }
        public string HoaDonSdt { get; set; }
        public string NgayTao { get; set; }
        public int TrangThai { get; set; }
        public string HoVaTen { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
    }
}
