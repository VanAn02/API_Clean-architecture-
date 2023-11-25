using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IBaiVietService
    {
        List<BaiVietDto> GetAll();
        BaiVietDto Get(int id);
        bool Add(BaiVietDto baiVietDto);
        bool Update(BaiVietDto baiVietDto);
        bool Delete(int id);
    }
}
