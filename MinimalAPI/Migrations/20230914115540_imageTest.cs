using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class imageTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AmountInStock", "Author", "Available", "Genre", "Image", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 0, "Jrr. Tolkien", true, "Fantasy", null, 1954, "Lord Of The Rings" },
                    { 2, 0, "Marcel Proust", true, "Fiction", null, 1913, "In Search Of Lost Time" },
                    { 3, 0, "Graham Hancock", false, "Pseudoarcheology", null, 1995, "Fingerprints Of the Gods" },
                    { 4, 0, "Richard Dawkins", true, "Fact", null, 1995, "The God Delusion" },
                    { 5, 0, "Unknown / King James Bible", true, "Religious Text", null, 0, "The Holy Bible" }
                });
        }
    }
}
