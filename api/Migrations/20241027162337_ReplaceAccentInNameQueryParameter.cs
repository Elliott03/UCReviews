using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceAccentInNameQueryParameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE DiningHall SET NameQueryParameter = REPLACE(NameQueryParameter, 'Café', 'Cafe') WHERE NameQueryParameter LIKE '%Café%'"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "UPDATE DiningHall SET NameQueryParameter = REPLACE(NameQueryParameter, 'Cafe', 'Café') WHERE NameQueryParameter LIKE '%Cafe%'"
            );
        }
    }
}
