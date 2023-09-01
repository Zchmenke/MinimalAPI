using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinimalAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Available", "Genre", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "Jrr. Tolkien", true, "Fantasy", 1954, "Lord Of The Rings" },
                    { 2, "Marcel Proust", true, "Fiction", 1913, "In Search Of Lost Time" },
                    { 3, "Graham Hancock", false, "Pseudoarcheology", 1995, "Fingerprints Of the Gods" },
                    { 4, "Richard Dawkins", true, "Fact", 1995, "The God Delusion" },
                    { 5, "Unknown / King James Bible", true, "Religious Text", 0, "The Holy Bible" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
