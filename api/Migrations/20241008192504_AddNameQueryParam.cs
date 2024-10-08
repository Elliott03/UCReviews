using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddNameQueryParam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameQueryParameter",
                table: "ParkingGarage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 1,
                column: "NameQueryParameter",
                value: "CCM");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 2,
                column: "NameQueryParameter",
                value: "Calhoun");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 3,
                column: "NameQueryParameter",
                value: "Campus_Green");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 4,
                column: "NameQueryParameter",
                value: "Clifton_Court");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 5,
                column: "NameQueryParameter",
                value: "Clifton_Lots");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 6,
                column: "NameQueryParameter",
                value: "Corry");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 7,
                column: "NameQueryParameter",
                value: "Digital_Futures");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 8,
                column: "NameQueryParameter",
                value: "Stratford_Heights");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 9,
                column: "NameQueryParameter",
                value: "University_Avenue");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 10,
                column: "NameQueryParameter",
                value: "Varsity_Village");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 11,
                column: "NameQueryParameter",
                value: "Woodside_Avenue");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 12,
                column: "NameQueryParameter",
                value: "Blood_Cancer_Healing_Center");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 13,
                column: "NameQueryParameter",
                value: "Eden");

            migrationBuilder.UpdateData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 14,
                column: "NameQueryParameter",
                value: "Kingsgate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameQueryParameter",
                table: "ParkingGarage");
        }
    }
}
