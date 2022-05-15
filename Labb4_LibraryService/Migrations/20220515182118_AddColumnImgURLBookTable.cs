using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_LibraryService.Migrations
{
    public partial class AddColumnImgURLBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Books");
        }
    }
}
