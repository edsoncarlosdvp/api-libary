using Microsoft.EntityFrameworkCore.Migrations;

namespace LibaryApi.Migrations
{
    public partial class AddedFieldImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Libary",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Libary");
        }
    }
}
