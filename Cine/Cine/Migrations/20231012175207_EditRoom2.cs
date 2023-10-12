using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Migrations
{
    public partial class EditRoom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaID",
                table: "Seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaID",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
