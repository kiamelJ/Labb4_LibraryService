using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_LibraryService.Migrations
{
    public partial class RemovedColumnIsBorrowesInTableCustomerBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Customer_Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Customer_Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 2, 1 },
                column: "IsBorrowed",
                value: true);

            migrationBuilder.UpdateData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 5, 4 },
                column: "IsBorrowed",
                value: true);
        }
    }
}
