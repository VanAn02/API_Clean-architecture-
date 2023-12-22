using AutoMapper;
using Shop.Applicationn.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<NguoiDung,NguoiDungDto>().ReverseMap();
            CreateMap<BaiViet,BaiVietDto>().ReverseMap();
            CreateMap<Tour,TourDto>().ReverseMap();
            CreateMap<DatTour, DatTourDto>().ReverseMap();
            CreateMap<HoaDon, HoaDonDto>().ReverseMap();
            CreateMap<ChiTietHoaDon, ChiTietHoaDonDto>().ReverseMap();
            CreateMap<EmailDto, EmailDto>().ReverseMap();
        }
    }
}
