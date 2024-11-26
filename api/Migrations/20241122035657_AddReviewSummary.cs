using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewSummary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewSummary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DormId = table.Column<int>(type: "int", nullable: true),
                    ParkingGarageId = table.Column<int>(type: "int", nullable: true),
                    DiningHallId = table.Column<int>(type: "int", nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(10,9)", precision: 10, scale: 9, nullable: false),
                    TotalReviews = table.Column<int>(type: "int", nullable: false),
                    SummaryText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewSummary_DiningHall_DiningHallId",
                        column: x => x.DiningHallId,
                        principalTable: "DiningHall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewSummary_Dorm_DormId",
                        column: x => x.DormId,
                        principalTable: "Dorm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReviewSummary_ParkingGarage_ParkingGarageId",
                        column: x => x.ParkingGarageId,
                        principalTable: "ParkingGarage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewSummary_DiningHallId",
                table: "ReviewSummary",
                column: "DiningHallId",
                unique: true,
                filter: "[DiningHallId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewSummary_DormId",
                table: "ReviewSummary",
                column: "DormId",
                unique: true,
                filter: "[DormId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewSummary_ParkingGarageId",
                table: "ReviewSummary",
                column: "ParkingGarageId",
                unique: true,
                filter: "[ParkingGarageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewSummary");
        }
    }
}
