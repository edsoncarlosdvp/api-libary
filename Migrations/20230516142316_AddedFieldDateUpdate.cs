using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibaryApi.Migrations
{
    public partial class AddedFieldDateUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdatedDb",
                table: "Libary",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdatedDb",
                table: "Libary");
        }
    }
}
