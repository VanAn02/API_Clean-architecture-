using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class sjdshdgsssaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietHoaDon_Tour_HoaDonId",
                table: "ChiTietHoaDon",
                column: "HoaDonId",
                principalTable: "Tour",
                principalColumn: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietHoaDon_Tour_HoaDonId",
                table: "ChiTietHoaDon");
        }
    }
}
