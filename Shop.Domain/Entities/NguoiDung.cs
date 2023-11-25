using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string? TenDangNhap { get; set; }
        public string? Avartar { get; set; }
        public string? MatKhau { get; set; }
        public string? HoTen { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        public virtual ICollection<DatTour> DatTours { get; set; }
    }
}
