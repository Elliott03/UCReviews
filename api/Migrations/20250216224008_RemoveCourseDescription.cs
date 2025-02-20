using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCourseDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "This capstone course is part 1 of the senior level course designed to allow students to review, analyze and integrate the work completed towards the bachelor of science in Information Technology degree. The student will complete an approved academic project, paper, and presentation that demonstrates mastery of the BSIT degree requirements.");

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "This capstone course is part 2 of the senior level course designed to allow students to review, analyze and integrate the work completed towards the bachelor of science in Information Technology degree. The student will complete an approved academic project, paper, and presentation that demonstrates mastery of the BSIT degree requirements.");
        }
    }
}
