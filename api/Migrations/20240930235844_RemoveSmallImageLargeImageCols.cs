using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSmallImageLargeImageCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeImage",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Smallimage",
                table: "Building");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LargeImage",
                table: "Building",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Smallimage",
                table: "Building",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
