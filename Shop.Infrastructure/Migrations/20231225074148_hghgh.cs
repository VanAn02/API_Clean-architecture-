using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class hghgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungHinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quyen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.NguoiDungId);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnhTour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhuVuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhoiHanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhuongTien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachSan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourId);
                });

            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    BaiVietId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnhBaiViet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.BaiVietId);
                    table.ForeignKey(
                        name: "FK_BaiViet_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungId");
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NguoiDungId = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoaDonSdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.HoaDonId);
                    table.ForeignKey(
                        name: "FK_HoaDon_NguoiDung_NguoiDungId",
                        column: x => x.NguoiDungId,
                        principalTable: "NguoiDung",
                        principalColumn: "NguoiDungId");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    ChiTietHoaDontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.ChiTietHoaDontId);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDon",
                        principalColumn: "HoaDonId");
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_NguoiDungId",
                table: "BaiViet",
                column: "NguoiDungId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_HoaDonId",
                table: "ChiTietHoaDon",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_TourId",
                table: "ChiTietHoaDon",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NguoiDungId",
                table: "HoaDon",
                column: "NguoiDungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "NguoiDung");
        }
    }
}
