﻿using AutoMapper;
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
    public class NguoiDungService : INguoiDungService
    {
        private readonly INguoiDungRepo _nguoiDungRepo;
        private readonly IMapper _mapper;
        public NguoiDungService(INguoiDungRepo nguoiDungRepo, IMapper mapper)
        {
            _nguoiDungRepo = nguoiDungRepo;
            _mapper = mapper;
        }

        public bool Create(NguoiDungDto nguoidung)
        {
            return _nguoiDungRepo.Add(_mapper.Map<NguoiDung>(nguoidung));
        }

        public bool Delete(int id)
        {
            return _nguoiDungRepo.Delete(id);
        }

        public NguoiDungDto Get(int id)
        {
            return _mapper.Map<NguoiDungDto>(_nguoiDungRepo.Get(id));
        }

        public List<NguoiDungDto> GetAll()
        {
            return _mapper.Map<List<NguoiDungDto>>(_nguoiDungRepo.GetAll());
        }

        public bool Register(NguoiDungDto nguoidung)
        {
            return _nguoiDungRepo.Add(_mapper.Map<NguoiDung>(nguoidung));
        }

        public bool Update(NguoiDungDto nguoidung)
        {
            try
            {
                var existingEntity = _nguoiDungRepo.Get(nguoidung.NguoiDungId);

                if (existingEntity != null)
                {
                    _mapper.Map(nguoidung, existingEntity);

                    _nguoiDungRepo.Update(existingEntity);

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
    }
}
