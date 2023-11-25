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
        bool Add(NguoiDungDto nguoiDungDto);
        bool Update(NguoiDungDto nguoiDungDto);
        bool Delete(int id);
    }
}
