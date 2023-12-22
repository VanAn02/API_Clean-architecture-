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
    public class HoaDonService : IHoaDonService
    {
        private readonly IHoaDonRepo _hoadonRepo;
        private readonly IMapper _mapper;
        public HoaDonService (IHoaDonRepo hoadonRepo, IMapper mapper)
        {
            _hoadonRepo = hoadonRepo;
            _mapper = mapper;
        }
        public List<HoaDonDto> GetAll()
        {
            return _mapper.Map<List<HoaDonDto>>(_hoadonRepo.GetAll());
        }
        public HoaDonDto Get(int id)
        {
            return _mapper.Map<HoaDonDto>(_hoadonRepo.Get(id));
        }
        public bool Add(HoaDonDto HoaDonDto)
        {
            return _hoadonRepo.Add(_mapper.Map<HoaDon>(HoaDonDto));
        }
        public bool Update(HoaDonDto HoaDonDto)
        {
            return _hoadonRepo.Update(_mapper.Map<HoaDon>(HoaDonDto));
        }
        public bool Delete(int id)
        {
            return _hoadonRepo.Delete(id);
        }
    }
}
