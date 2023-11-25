using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface IDatTourService

    {
        List<DatTourDto> GetAll();
        DatTourDto Get(int id);
        bool Add(DatTourDto datTourDto);
        bool Update(DatTourDto datTourDto);
        bool Delete(int id);
    }
}
