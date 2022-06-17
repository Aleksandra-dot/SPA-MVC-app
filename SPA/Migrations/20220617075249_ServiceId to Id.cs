using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA.Migrations
{
    public partial class ServiceIdtoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Services",
                newName: "ServiceId");
        }
    }
}
