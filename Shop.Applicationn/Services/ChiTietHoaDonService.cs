using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class ChiTietHoaDonService : IChiTietHoaDonService
    {
        private readonly IChiTietHoaDonRepo _chitiethoadonRepo;
        private readonly ITourRepo _TourRepo;
        private readonly IMapper _mapper;
        public ChiTietHoaDonService(IChiTietHoaDonRepo chitiethoadonRepo, IMapper mapper, ITourRepo tourrepo)
        {
            _chitiethoadonRepo = chitiethoadonRepo;
            _mapper = mapper;
            _TourRepo= tourrepo;
        }
        public List<ChiTietHoaDonDto> GetAll()
        {
            return _mapper.Map<List<ChiTietHoaDonDto>>(_chitiethoadonRepo.GetAll());
        }
        public ChiTietHoaDonDto Get(int id)
        {
            return _mapper.Map<ChiTietHoaDonDto>(_chitiethoadonRepo.Get(id));
        }
        public bool Add(ChiTietHoaDonDto ChiTietHoaDonDto)
        {
            return _chitiethoadonRepo.Add(_mapper.Map<ChiTietHoaDon>(ChiTietHoaDonDto));
        }
        public bool Update(ChiTietHoaDonDto ChiTietHoaDonDto)
        {
            return _chitiethoadonRepo.Update(_mapper.Map<ChiTietHoaDon>(ChiTietHoaDonDto));
        }
        public bool Delete(int id)
        {
            return _chitiethoadonRepo.Delete(id);
        }
        public IEnumerable<DetailHoaDon> GetByIdHoaDon(int id)
        {
            var query=from CHiTietHoaDon in _chitiethoadonRepo.GetAll().Where(x=>x.HoaDonId==id).ToList()
                      join Tourtbl in _TourRepo.GetAll().ToList() on CHiTietHoaDon.TourId equals Tourtbl.TourId
                      select new DetailHoaDon
                      {
                          Anh=Tourtbl.AnhTour,
                          Gia=Int32.Parse(CHiTietHoaDon.Gia),
                          SoLuong= CHiTietHoaDon.SoLuong,
                          TenTour=Tourtbl.TenTour,
                      };
            return query.ToList();
        }
    }

}
