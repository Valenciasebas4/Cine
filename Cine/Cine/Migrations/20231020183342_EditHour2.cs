using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cine.Migrations
{
    public partial class EditHour2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hours_MovieId",
                table: "Hours");

            migrationBuilder.DropColumn(
                name: "EndignTime",
                table: "Hours");

            migrationBuilder.CreateIndex(
                name: "IX_Hours_MovieId_StarTime_Date",
                table: "Hours",
                columns: new[] { "MovieId", "StarTime", "Date" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hours_MovieId_StarTime_Date",
                table: "Hours");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndignTime",
                table: "Hours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Hours_MovieId",
                table: "Hours",
                column: "MovieId");
        }
    }
}
