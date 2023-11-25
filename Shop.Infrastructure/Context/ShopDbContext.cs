using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<DatTour> DatTours { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>(e =>
            {
                e.ToTable("NguoiDung");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).IsRequired();
                e.Property(e => e.TenDangNhap).IsRequired().HasMaxLength(30);
            });
            modelBuilder.Entity<BaiViet>(e =>
            {
                e.ToTable("BaiViet");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).IsRequired();
                e.Property(e => e.TieuDe).IsRequired().HasMaxLength(100);
                e.HasOne(x => x.NguoiDung).WithMany(p => p.BaiViets).HasForeignKey(x => x.NguoiDungId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Tour>(e =>
            {
                e.ToTable("Tour");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).IsRequired();
                e.Property(e => e.TenTour).IsRequired().HasMaxLength(100);
            });
            modelBuilder.Entity<DatTour>(e =>
            {
                e.ToTable("DatTour");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id).IsRequired();
                e.HasOne(x => x.NguoiDung).WithMany(p => p.DatTours).HasForeignKey(x => x.NguoiDungId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(x => x.Tour).WithMany(p => p.DatTours).HasForeignKey(x => x.TourId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
