using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddParkingGarages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "DormId",
                table: "Review",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParkingGarageId",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParkingGarage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermitRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingGarage", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingGarage",
                columns: new[] { "Id", "Address", "Campus", "Latitude", "Longitude", "Name", "PermitRequired" },
                values: new object[,]
                {
                    { 1, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.129894, -84.516852, "CCM Garage", false },
                    { 2, "230 Calhoun St, Cincinnati, OH 45219", "Uptown Campus", 39.128439, -84.516615999999999, "Calhoun Garage", false },
                    { 3, "2935 Campus Green Dr, Cincinnati, OH 45221", "Uptown Campus", 39.135716000000002, -84.515223000000006, "Campus Green Garage", false },
                    { 4, "CCM Blvd, Cincinnati, OH 45219", "Uptown Campus", 39.134303000000003, -84.517270999999994, "Clifton Court Garage", false },
                    { 5, "2915 Clifton Ave, Cincinnati, OH 45220", "Uptown Campus", 39.134689999999999, -84.520307000000003, "Clifton Lots", true },
                    { 6, "2529 Scioto Ln, Cincinnati, OH 45219", "Uptown Campus", 39.129001000000002, -84.512904000000006, "Corry Garage", false },
                    { 7, "3080 Exploration Ave, Cincinnati, OH 45206", "Uptown Campus", 39.134089000000003, -84.494940999999997, "Digital Futures", false },
                    { 8, "2630 Stratford Ave, Cincinnati, OH 45220", "Uptown Campus", 39.130840999999997, -84.521377000000001, "Stratford Heights Garage", true },
                    { 9, "40 W University Ave, Cincinnati, OH 45221", "Uptown Campus", 39.134614999999997, -84.510986000000003, "University Avenue Garage", false },
                    { 10, "200 Varsity Village Drive, Cincinnati, OH 45221", "Uptown Campus", 39.130166000000003, -84.515963999999997, "Varsity Village Garage", false },
                    { 11, "2913 Woodside Drive, Cincinnati, OH 45219", "Uptown Campus", 39.135024999999999, -84.515180000000001, "Woodside Avenue Garage", false },
                    { 12, "3232 Healing Way, Cincinnati, OH 45229", "Medical Campus", 39.138082474177075, -84.501192464167943, "Blood Cancer Healing Center", false },
                    { 13, "3223 Eden Ave, Cincinnati, OH 45220", "Medical Campus", 39.137669000000002, -84.505159000000006, "Eden Garage", false },
                    { 14, "151 Goodman Dr, Cincinnati, OH 45219", "Medical Campus", 39.138082474177075, -84.501192464167943, "Kingsgate Garage", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ParkingGarageId",
                table: "Review",
                column: "ParkingGarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review",
                column: "DormId",
                principalTable: "Dorm",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_ParkingGarage_ParkingGarageId",
                table: "Review",
                column: "ParkingGarageId",
                principalTable: "ParkingGarage",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_ParkingGarage_ParkingGarageId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "ParkingGarage");

            migrationBuilder.DropIndex(
                name: "IX_Review_ParkingGarageId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ParkingGarageId",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "DormId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review",
                column: "DormId",
                principalTable: "Dorm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
