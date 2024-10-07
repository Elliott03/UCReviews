using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDormData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dorm",
                columns: new[] { "Id", "AverageRating", "Cost", "Description", "Name", "NameQueryParameter", "Style" },
                values: new object[,]
                {
                    { 1, 3m, "$", "Located in the heart of Clifton Heights, Calhoun Hall is known for its welcoming atmosphere and scenic views. Its community areas and study floor make it the perfect place to meet neighbors, cultivate friendships, and get involved in the UC community! The proximity to off- and on-campus dining options, as well as entertainment on Calhoun Street makes it an exciting and classic option when it comes to choosing where to live.", "Calhoun Hall", "Calhoun", "Traditional" },
                    { 2, 4m, "$$$", "Campus Recreation Center Hall is perfect for students that desire productivity and focus in their day-to-day life. It is located on MainStreet connected to the Rec Center and CenterCourt dining hall, making it the perfect environment for motivation.", "CRC", "CRC", "Suite" },
                    { 3, 2.9m, "$", "This newly renovated hall fosters some of the strongest community on campus and puts you at the center of so much activity. Sitting in the middle of campus and just a short walk from the sprawling Sigma Sigma Commons.", "Dabney Hall", "Dabney", "Traditional" },
                    { 4, 3m, "$", "Daniels Hall most likely matches what comes to mind when you think of a college residence hall. Its traditional-style structure establishes a welcoming and very social atmosphere on every floor.", "Daniels Hall", "Daniels", "Traditional" },
                    { 5, 4.5m, "$$", "UC’s newest addition to University Housing and is a wonderful place for students to live. Its unique architecture allows for suite-style rooms.", "Marian Spencer", "Marian_Spencer", "Junior Suite" },
                    { 6, 0m, "$$$$", "Renovated in 2013, Morgens Hall was built as one of the Three Sisters and is now a state-of-the-art building with many awards for its eco-friendly design.", "Morgens Hall", "Morgens", "Apartment" },
                    { 7, 0m, "$$$", "Schneider Hall is in a wonderful part of eastern main campus along Jefferson Avenue, and is close to multiple dining centers, shops, and restaurants.", "Schneider Hall", "Schneider", "Suite" },
                    { 8, 0m, "$$$$", "Located close to multiple dining centers, Scioto Hall provides a spacious environment with suite-style living and plenty of community spaces.", "Scioto Hall", "Scioto", "Apartment" },
                    { 9, 0m, "$", "Siddall Hall includes the CCM themed community and is known for its communal activities such as ping pong tournaments and late-night ice cream parties.", "Siddall Hall", "Siddall", "Traditional" },
                    { 10, 0m, "$$$$", "One of UC’s newest off-campus housing communities, The Deacon offers distinctive amenities such as a movie theater and arcade.", "The Deacon", "Deacon", "Apartment" },
                    { 11, 0m, "$$$$", "Newly constructed apartments just three blocks from campus, with floor plans and amenities ideal for building community among residents.", "The Eden", "Eden", "Apartment" },
                    { 12, 0m, "$$$", "Turner Hall is home to multiple Living-Learning Communities and has ADA accessible accommodations available.", "Turner Hall", "Turner", "Suite" },
                    { 13, 3.5m, "$$$$", "University Edge apartments provide near-campus residency options with a sprawling courtyard and proximity to the Cincinnati Zoo.", "University Edge", "Edge", "Apartment" },
                    { 14, 1m, "$$$$", "University Park Apartments offer students an off-campus lifestyle with all the benefits of on-campus living, above many restaurants and shops.", "UPA", "UPA", "Apartment" },
                    { 15, 3.8m, "$$$$", "Located on Calhoun Street, U Square provides apartment-style living with a relaxing and independent lifestyle while offering convenience to businesses.", "U Square", "USquare", "Apartment" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dorm",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
