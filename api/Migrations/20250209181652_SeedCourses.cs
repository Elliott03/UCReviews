using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Description", "Name", "NameQueryParameter", "Number", "Subject" },
                values: new object[,]
                {
                    { 1, "This capstone course is part 1 of the senior level course designed to allow students to review, analyze and integrate the work completed towards the bachelor of science in Information Technology degree. The student will complete an approved academic project, paper, and presentation that demonstrates mastery of the BSIT degree requirements.", "SR CAPSTONE PROJECT I", "IT5003C", "5003C", "IT" },
                    { 2, "This capstone course is part 2 of the senior level course designed to allow students to review, analyze and integrate the work completed towards the bachelor of science in Information Technology degree. The student will complete an approved academic project, paper, and presentation that demonstrates mastery of the BSIT degree requirements.", "SR CAPSTONE PROJECT II", "IT5004C", "5004C", "IT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
