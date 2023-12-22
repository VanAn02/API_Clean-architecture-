using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface INguoiDungService
    {
        List<NguoiDungDto> GetAll();
        NguoiDungDto Get(int id);
        bool Register(NguoiDungDto nguoidung);
        bool Create(NguoiDungDto nguoidung);
        bool Delete(int id);
        bool Update(NguoiDungDto nguoidung);
    }
}
