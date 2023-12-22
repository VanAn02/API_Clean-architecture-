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
        private readonly IMapper _mapper;
        public ChiTietHoaDonService(IChiTietHoaDonRepo chitiethoadonRepo, IMapper mapper)
        {
            _chitiethoadonRepo = chitiethoadonRepo;
            _mapper = mapper;
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
    }

}
