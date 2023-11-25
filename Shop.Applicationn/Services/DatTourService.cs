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
    public class DatTourService:IDatTourService
    {
        private readonly IDatTourRepo _datTourRepo;
        private readonly IMapper _mapper;
        public DatTourService(IDatTourRepo datTourRepo, IMapper mapper)
        {
            _datTourRepo = datTourRepo;
            _mapper = mapper;
        }
        public List<DatTourDto> GetAll()
        {
            return _mapper.Map<List<DatTourDto>>(_datTourRepo.GetAll());
        }
        public DatTourDto Get(int id)
        {
            return _mapper.Map<DatTourDto>(_datTourRepo.Get(id));
        }
        public bool Add(DatTourDto DatTourDto)
        {
            return _datTourRepo.Add(_mapper.Map<DatTour>(DatTourDto));
        }
        public bool Update(DatTourDto DatTourDto)
        {
            return _datTourRepo.Update(_mapper.Map<DatTour>(DatTourDto));
        }
        public bool Delete(int id)
        {
            return _datTourRepo.Delete(id);
        }
    }
}
