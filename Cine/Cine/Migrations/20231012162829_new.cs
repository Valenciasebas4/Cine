using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Classifications_ClassificationId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genders_GenderId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Classifications_ClassificationId",
                table: "Movies",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genders_GenderId",
                table: "Movies",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Classifications_ClassificationId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genders_GenderId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassificationId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Classifications_ClassificationId",
                table: "Movies",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genders_GenderId",
                table: "Movies",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
