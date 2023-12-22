using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Dto
{
    public class NguoiDungDto
    {
        public int NguoiDungId { get; set; }
        public string? NguoiDungHinhAnh { get; set; }
        public string? HoVaTen { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public string? Quyen { get; set; }

    }
}
