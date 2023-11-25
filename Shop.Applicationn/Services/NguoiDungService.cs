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
    public class NguoiDungService:INguoiDungService
    {
        private readonly INguoiDungRepo _nguoidungRepo;
        private readonly IMapper _mapper;
        public NguoiDungService(INguoiDungRepo NguoiDungRepo, IMapper mapper)
        {
            _nguoidungRepo = NguoiDungRepo;
            _mapper = mapper;
        }
        public List<NguoiDungDto> GetAll()
        {
            return _mapper.Map<List<NguoiDungDto>>(_nguoidungRepo.GetAll());
        }
        public NguoiDungDto Get(int id)
        {
            return _mapper.Map<NguoiDungDto>(_nguoidungRepo.Get(id));
        }
        public bool Add(NguoiDungDto NguoiDungDto)
        {
            return _nguoidungRepo.Add(_mapper.Map<NguoiDung>(NguoiDungDto));
        }
        public bool Update(NguoiDungDto NguoiDungDto)
        {
            return _nguoidungRepo.Update(_mapper.Map<NguoiDung>(NguoiDungDto));
        }
        public bool Delete(int id)
        {
            return _nguoidungRepo.Delete(id);
        }
    }
}
