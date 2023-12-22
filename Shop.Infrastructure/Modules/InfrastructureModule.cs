using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Repositories;
using Shop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services.AddScoped<INguoiDungRepo, NguoiDungRepo>();
            services.AddScoped<IBaiVietRepo, BaiVietRepo>();
            services.AddScoped<ITourRepo,TourRepo>();
            services.AddScoped<IDatTourRepo, DatTourRepo>();
            services.AddScoped<IHoaDonRepo, HoaDonRepo>();
            services.AddScoped<IChiTietHoaDonRepo, ChiTietHoaDonRepo>();
            return services;
        }    
    }
}
