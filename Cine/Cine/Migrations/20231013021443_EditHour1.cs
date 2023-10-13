using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Migrations
{
    public partial class EditHour1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Movies_MovieId",
                table: "Hours");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Hours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Movies_MovieId",
                table: "Hours",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Movies_MovieId",
                table: "Hours");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Hours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Movies_MovieId",
                table: "Hours",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }
    }
}
