using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeWith_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class MasterDBaddedforcurrencyandLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "currency",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "currency",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "currency",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "currency",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "languages",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
