using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class TourService : ITourService
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
        public bool Delete(int id)
        {
            return _ITourRepo.Delete(id);
        }
        public bool Update(TourDto tour)
        {
            try
            {
                var existingEntity = _ITourRepo.Get(tour.TourId);

                if (existingEntity != null)
                {
                    _mapper.Map(tour, existingEntity);

                    _ITourRepo.Update(existingEntity);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public List<TourDto> GetByMien(string value)
        {
            return _mapper.Map<List<TourDto>>(_ITourRepo.GetAll().Where(x=>x.KhuVuc==value));
        }

        public List<TourDto> Search(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return _mapper.Map<List<TourDto>>(_ITourRepo.GetAll());
            }
            else
            {
                var search = value.Trim().ToLower();
                var query = _ITourRepo.GetAll()
                    .Where(tour =>
                        tour.Gia.ToLower().Contains(search) ||
                        tour.KhachSan.ToLower().Contains(search) ||
                        tour.KhoiHanh.ToLower().Contains(search) ||
                        tour.KhuVuc.ToLower().Contains(search) ||
                        tour.TenTour.ToLower().Contains(search) ||
                        tour.PhuongTien.ToLower().Contains(search) ||
                        tour.ThoiGian.ToLower().Contains(search)
                    );
                return _mapper.Map<List<TourDto>>(query.ToList());
            }
        }

    }
}

