using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RenameBuildingToDorm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Building_BuildingId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Building");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "Review",
                newName: "DormId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BuildingId",
                table: "Review",
                newName: "IX_Review_DormId");

            migrationBuilder.CreateTable(
                name: "Dorm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NameQueryParameter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dorm", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review",
                column: "DormId",
                principalTable: "Dorm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Dorm_DormId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Dorm");

            migrationBuilder.RenameColumn(
                name: "DormId",
                table: "Review",
                newName: "BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_DormId",
                table: "Review",
                newName: "IX_Review_BuildingId");

            migrationBuilder.CreateTable(
                name: "Building",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameQueryParameter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Building_BuildingId",
                table: "Review",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
