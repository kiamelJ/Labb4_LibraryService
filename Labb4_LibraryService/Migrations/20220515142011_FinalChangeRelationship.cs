using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_LibraryService.Migrations
{
    public partial class FinalChangeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Books",
                table: "Customer_Books");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Books_BookId",
                table: "Customer_Books");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer_Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Books",
                table: "Customer_Books",
                columns: new[] { "BookId", "CustomerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer_Books",
                table: "Customer_Books");

            migrationBuilder.DeleteData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Customer_Books",
                keyColumns: new[] { "BookId", "CustomerId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customer_Books",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer_Books",
                table: "Customer_Books",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Customer_Books",
                columns: new[] { "Id", "BookId", "BorrowDate", "CustomerId", "IsBorrowed", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, new DateTime(1999, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2002, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, null },
                    { 4, 3, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Books_BookId",
                table: "Customer_Books",
                column: "BookId");
        }
    }
}
