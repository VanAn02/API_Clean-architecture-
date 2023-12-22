using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IChiTietHoaDonService
    {
        List<ChiTietHoaDonDto> GetAll();
        ChiTietHoaDonDto Get(int id);
        bool Add(ChiTietHoaDonDto chitiethoadon);
        bool Update(ChiTietHoaDonDto chitiethoadon);
        bool Delete(int id);
    }
}
