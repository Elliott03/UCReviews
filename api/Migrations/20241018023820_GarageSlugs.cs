using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class GarageSlugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Dorm");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "ParkingGarage",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 1,
                column: "Slug",
                value: "ccm");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 2,
                column: "Slug",
                value: "calhoun");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 3,
                column: "Slug",
                value: "campus-green");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 4,
                column: "Slug",
                value: "clifton-court");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 5,
                column: "Slug",
                value: "clifton-lots");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 6,
                column: "Slug",
                value: "corry");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 7,
                column: "Slug",
                value: "digital-futures");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 8,
                column: "Slug",
                value: "stratford-heights");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 9,
                column: "Slug",
                value: "university-avenue");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 10,
                column: "Slug",
                value: "varsity-village");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 11,
                column: "Slug",
                value: "woodside-avenue");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 12,
                column: "Slug",
                value: "blood-cancer-healing-center");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 13,
                column: "Slug",
                value: "eden");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 14,
                column: "Slug",
                value: "kingsgate");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingGarage_Slug",
                table: "ParkingGarage",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ParkingGarage_Slug",
                table: "ParkingGarage");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "ParkingGarage");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Dorm",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 1,
                column: "AverageRating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 2,
                column: "AverageRating",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 3,
                column: "AverageRating",
                value: 2.9m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 4,
                column: "AverageRating",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 5,
                column: "AverageRating",
                value: 4.5m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 6,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 7,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 8,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 9,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 10,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 11,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 12,
                column: "AverageRating",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 13,
                column: "AverageRating",
                value: 3.5m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 14,
                column: "AverageRating",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 15,
                column: "AverageRating",
                value: 3.8m);
        }
    }
}
