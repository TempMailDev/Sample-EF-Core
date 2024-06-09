using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeWith_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currency",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfPages = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LanguagesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_languages_LanguagesID",
                        column: x => x.LanguagesID,
                        principalTable: "languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookPrices_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookPrices_currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "currency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "currency",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Indian INR", "INR" },
                    { 2, "USA Dollar", "Dollar" },
                    { 3, "Euro", "Euro" },
                    { 4, "Japanese yen", "Yen" }
                });

            migrationBuilder.InsertData(
                table: "languages",
                columns: new[] { "ID", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Hin Hindi", "Hindi" },
                    { 2, "en English", "English" },
                    { 3, "Telugu", "Telugu" },
                    { 4, "Japanese", "Nihongo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookPrices_BookId",
                table: "bookPrices",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookPrices_CurrencyId",
                table: "bookPrices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_books_LanguagesID",
                table: "books",
                column: "LanguagesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookPrices");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
