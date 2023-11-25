using Shop.Applicationn.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public interface ITourService
    {
        List<TourDto> GetAll();
        TourDto Get(int id);
        bool Add(TourDto TourDto);
        bool Update(TourDto TourDto);
        bool Delete(int id);
    }
}
