using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeWith_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addedfewtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguagesID",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_books_LanguagesID",
                table: "books",
                column: "LanguagesID");

            migrationBuilder.CreateIndex(
                name: "IX_bookPrices_BookId",
                table: "bookPrices",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_bookPrices_CurrencyId",
                table: "bookPrices",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_languages_LanguagesID",
                table: "books",
                column: "LanguagesID",
                principalTable: "languages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_languages_LanguagesID",
                table: "books");

            migrationBuilder.DropTable(
                name: "bookPrices");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "currency");

            migrationBuilder.DropIndex(
                name: "IX_books_LanguagesID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "LanguagesID",
                table: "books");
        }
    }
}
