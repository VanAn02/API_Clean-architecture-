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
    public class BaiVietService : IBaiVietService
    {
        private readonly IBaiVietRepo _baivietRepo;
        private readonly IMapper _mapper;
        public BaiVietService(IBaiVietRepo baivietRepo, IMapper mapper)
        {
            _baivietRepo = baivietRepo;
            _mapper = mapper;
        }
        public List<BaiVietDto> GetAll()
        {
            return _mapper.Map<List<BaiVietDto>>(_baivietRepo.GetAll());
        }
        public BaiVietDto Get(int id)
        {
            return _mapper.Map<BaiVietDto>(_baivietRepo.Get(id));
        }
        public bool Add(BaiVietDto BaiVietDto)
        {
            return _baivietRepo.Add(_mapper.Map<BaiViet>(BaiVietDto));
        }
        public bool Update(BaiVietDto BaiVietDto)
        {
            return _baivietRepo.Update(_mapper.Map<BaiViet>(BaiVietDto));
        }
        public bool Delete(int id)
        {
            return _baivietRepo.Delete(id);
        }
    }
}
