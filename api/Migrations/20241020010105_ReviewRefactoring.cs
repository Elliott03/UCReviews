using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ReviewRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.AlterColumn<decimal>(
                name: "StarRating",
                table: "Review",
                type: "decimal(2,1)",
                precision: 2,
                scale: 1,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ParkingGarage",
                columns: new[] { "Id", "Address", "Campus", "Latitude", "Longitude", "Name", "NameQueryParameter", "PermitRequired", "Slug" },
                values: new object[,]
                {
                    { 16, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.129894, -84.516852, "CCM Garage", "CCM", false, "ccm" },
                    { 17, "230 Calhoun St, Cincinnati, OH 45219", "Uptown Campus", 39.128439, -84.516615999999999, "Calhoun Garage", "Calhoun", false, "calhoun" },
                    { 18, "2935 Campus Green Dr, Cincinnati, OH 45221", "Uptown Campus", 39.135716000000002, -84.515223000000006, "Campus Green Garage", "Campus_Green", false, "campus-green" },
                    { 19, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.134303000000003, -84.517270999999994, "Clifton Court Garage", "Clifton_Court", false, "clifton-court" },
                    { 20, "2915 Clifton Ave, Cincinnati, OH 45220", "Uptown Campus", 39.134689999999999, -84.520307000000003, "Clifton Lots", "Clifton_Lots", true, "clifton-lots" },
                    { 21, "2529 Scioto Ln, Cincinnati, OH 45219", "Uptown Campus", 39.129001000000002, -84.512904000000006, "Corry Garage", "Corry", false, "corry" },
                    { 22, "3080 Exploration Ave, Cincinnati, OH 45206", "Uptown Campus", 39.134089000000003, -84.494940999999997, "Digital Futures", "Digital_Futures", false, "digital-futures" },
                    { 23, "2630 Stratford Ave, Cincinnati, OH 45220", "Uptown Campus", 39.130840999999997, -84.521377000000001, "Stratford Heights Garage", "Stratford_Heights", true, "stratford-heights" },
                    { 24, "40 W University Ave, Cincinnati, OH 45221", "Uptown Campus", 39.134614999999997, -84.510986000000003, "University Avenue Garage", "University_Avenue", false, "university-avenue" },
                    { 25, "200 Varsity Village Drive, Cincinnati, OH 45221", "Uptown Campus", 39.130166000000003, -84.515963999999997, "Varsity Village Garage", "Varsity_Village", false, "varsity-village" },
                    { 26, "2913 Woodside Drive, Cincinnati, OH 45219", "Uptown Campus", 39.135024999999999, -84.515180000000001, "Woodside Avenue Garage", "Woodside_Avenue", false, "woodside-avenue" },
                    { 27, "3232 Healing Way, Cincinnati, OH 45229", "Medical Campus", 39.138082474177075, -84.501192464167943, "Blood Cancer Healing Center", "Blood_Cancer_Healing_Center", false, "blood-cancer-healing-center" },
                    { 28, "3223 Eden Ave, Cincinnati, OH 45220", "Medical Campus", 39.137669000000002, -84.505159000000006, "Eden Garage", "Eden", false, "eden" },
                    { 29, "151 Goodman Dr, Cincinnati, OH 45219", "Medical Campus", 39.138082474177075, -84.501192464167943, "Kingsgate Garage", "Kingsgate", false, "kingsgate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ParkingGarage",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.AlterColumn<decimal>(
                name: "StarRating",
                table: "Review",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,1)",
                oldPrecision: 2,
                oldScale: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewText",
                table: "Review",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ParkingGarage",
                columns: new[] { "Id", "Address", "Campus", "Latitude", "Longitude", "Name", "NameQueryParameter", "PermitRequired", "Slug" },
                values: new object[,]
                {
                    { 1, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.129894, -84.516852, "CCM Garage", "CCM", false, "ccm" },
                    { 2, "230 Calhoun St, Cincinnati, OH 45219", "Uptown Campus", 39.128439, -84.516615999999999, "Calhoun Garage", "Calhoun", false, "calhoun" },
                    { 3, "2935 Campus Green Dr, Cincinnati, OH 45221", "Uptown Campus", 39.135716000000002, -84.515223000000006, "Campus Green Garage", "Campus_Green", false, "campus-green" },
                    { 4, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.134303000000003, -84.517270999999994, "Clifton Court Garage", "Clifton_Court", false, "clifton-court" },
                    { 5, "2915 Clifton Ave, Cincinnati, OH 45220", "Uptown Campus", 39.134689999999999, -84.520307000000003, "Clifton Lots", "Clifton_Lots", true, "clifton-lots" },
                    { 6, "2529 Scioto Ln, Cincinnati, OH 45219", "Uptown Campus", 39.129001000000002, -84.512904000000006, "Corry Garage", "Corry", false, "corry" },
                    { 7, "3080 Exploration Ave, Cincinnati, OH 45206", "Uptown Campus", 39.134089000000003, -84.494940999999997, "Digital Futures", "Digital_Futures", false, "digital-futures" },
                    { 8, "2630 Stratford Ave, Cincinnati, OH 45220", "Uptown Campus", 39.130840999999997, -84.521377000000001, "Stratford Heights Garage", "Stratford_Heights", true, "stratford-heights" },
                    { 9, "40 W University Ave, Cincinnati, OH 45221", "Uptown Campus", 39.134614999999997, -84.510986000000003, "University Avenue Garage", "University_Avenue", false, "university-avenue" },
                    { 10, "200 Varsity Village Drive, Cincinnati, OH 45221", "Uptown Campus", 39.130166000000003, -84.515963999999997, "Varsity Village Garage", "Varsity_Village", false, "varsity-village" },
                    { 11, "2913 Woodside Drive, Cincinnati, OH 45219", "Uptown Campus", 39.135024999999999, -84.515180000000001, "Woodside Avenue Garage", "Woodside_Avenue", false, "woodside-avenue" },
                    { 12, "3232 Healing Way, Cincinnati, OH 45229", "Medical Campus", 39.138082474177075, -84.501192464167943, "Blood Cancer Healing Center", "Blood_Cancer_Healing_Center", false, "blood-cancer-healing-center" },
                    { 13, "3223 Eden Ave, Cincinnati, OH 45220", "Medical Campus", 39.137669000000002, -84.505159000000006, "Eden Garage", "Eden", false, "eden" },
                    { 14, "151 Goodman Dr, Cincinnati, OH 45219", "Medical Campus", 39.138082474177075, -84.501192464167943, "Kingsgate Garage", "Kingsgate", false, "kingsgate" }
                });
        }
    }
}
