using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4_LibraryService.Migrations
{
    public partial class ModelCreateAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    BorrowDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true),
                    IsBorrowed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Books_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_Books_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Titel" },
                values: new object[,]
                {
                    { 1, "Lars Wilderäng", "Drönarhjärta" },
                    { 2, "Tom Clancy", "Jakten på Röd Oktober" },
                    { 3, "Lars Wilderäng", "Höstsol" },
                    { 4, "J.R.R. Tolkien", "Sagan om Ringen" },
                    { 5, "J.K. Rowling", "Harry Potter och Fenixorden" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "dexter@gmail.com", "Dexter", "075-321 44 50" },
                    { 2, "peggy@hotmail.com", "Peggy", "010-569 96 33" },
                    { 3, "atlas1337@yahoo.com", "Atlas", "070-897 87 47" },
                    { 4, "embla@myspace.com", "Embla", "070-103 71 13" },
                    { 5, "josh@guru.com", "Josh", "070-567 31 00" }
                });

            migrationBuilder.InsertData(
                table: "Customer_Books",
                columns: new[] { "Id", "BookId", "BorrowDate", "CustomerId", "IsBorrowed", "ReturnDate" },
                values: new object[,]
                {
                    { 3, 2, new DateTime(2022, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, null },
                    { 1, 1, new DateTime(1999, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, new DateTime(1999, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2002, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, false, new DateTime(2002, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, null },
                    { 4, 3, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, new DateTime(2022, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Books_BookId",
                table: "Customer_Books",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Books_CustomerId",
                table: "Customer_Books",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Books");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
