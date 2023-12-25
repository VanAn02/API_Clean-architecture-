using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IHoaDonService
    {
        List<HoaDonDto> GetAll();
        HoaDonDto Get(int id);
        bool Add(HoaDonDto hoadon);
        bool Update(HoaDonDto hoadon);
        bool Delete(int id);
        List<HoaDonDto> GetById(int id);

    }
}
