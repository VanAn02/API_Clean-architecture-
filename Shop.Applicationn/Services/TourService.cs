using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class TourService:ITourService
    {
        private readonly ITourRepo _ITourRepo;
        private readonly IMapper _mapper;
        public TourService(ITourRepo iTourRepo, IMapper mapper)
        {
            _ITourRepo = iTourRepo;
            _mapper = mapper;
        }
        public List<TourDto> GetAll()
        {
            return _mapper.Map<List<TourDto>>(_ITourRepo.GetAll());
        }
        public TourDto Get(int id)
        {
            return _mapper.Map<TourDto>(_ITourRepo.Get(id));
        }
        public bool Add(TourDto TourDto)
        {
            return _ITourRepo.Add(_mapper.Map<Tour>(TourDto));
        }
        public bool Update(TourDto TourDto)
        {
            return _ITourRepo.Update(_mapper.Map<Tour>(TourDto));
        }
        public bool Delete(int id)
        {
            return _ITourRepo.Delete(id);
        }
    }
}
