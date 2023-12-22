using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    public partial class sjdshdgsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatTour_HoaDon_HoaDonId",
                table: "DatTour");

            migrationBuilder.DropIndex(
                name: "IX_DatTour_HoaDonId",
                table: "DatTour");

            migrationBuilder.DropColumn(
                name: "HoaDonId",
                table: "DatTour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HoaDonId",
                table: "DatTour",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatTour_HoaDonId",
                table: "DatTour",
                column: "HoaDonId");

            migrationBuilder.AddForeignKey(
                name: "FK_DatTour_HoaDon_HoaDonId",
                table: "DatTour",
                column: "HoaDonId",
                principalTable: "HoaDon",
                principalColumn: "HoaDonId");
        }
    }
}
