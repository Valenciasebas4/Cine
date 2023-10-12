using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Migrations
{
    public partial class EditSeat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seats_NumberSeat",
                table: "Seats");

            migrationBuilder.AddColumn<bool>(
                name: "Busy",
                table: "Seats",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_NumberSeat_RoomId",
                table: "Seats",
                columns: new[] { "NumberSeat", "RoomId" },
                unique: true,
                filter: "[RoomId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Seats_NumberSeat_RoomId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "Busy",
                table: "Seats");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_NumberSeat",
                table: "Seats",
                column: "NumberSeat",
                unique: true);
        }
    }
}
