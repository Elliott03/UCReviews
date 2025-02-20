using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddCoursesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "ReviewSummary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameQueryParameter = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewSummary_CourseId",
                table: "ReviewSummary",
                column: "CourseId",
                unique: true,
                filter: "[CourseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CourseId",
                table: "Review",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewSummary_Course_CourseId",
                table: "ReviewSummary",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Course_CourseId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewSummary_Course_CourseId",
                table: "ReviewSummary");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_ReviewSummary_CourseId",
                table: "ReviewSummary");

            migrationBuilder.DropIndex(
                name: "IX_Review_CourseId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "ReviewSummary");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Review");
        }
    }
}
