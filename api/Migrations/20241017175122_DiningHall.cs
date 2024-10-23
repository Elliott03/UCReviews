using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class DiningHall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiningHallId",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DiningHall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludedInMealPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameQueryParameter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiningHall", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiningHall",
                columns: new[] { "Id", "Category", "Description", "IncludedInMealPlan", "Location", "Name", "NameQueryParameter" },
                values: new object[,]
                {
                    { 1, "Retail Dining", "Located on the second floor of the Tangeman University Center, Cincy Grill is home to grill favorites such as chicken tenders, smash burgers, loaded tots and much more.", "Meal Exchange", "Cincy Grill - Tangemen University Center, 2701 Bearcat Way", "Cincy Grill", "CincyGrill" },
                    { 2, "Retail Dining", "A favorite stop for breakfast, lunch, or dinner, Chick-fil-A offers premium chicken sandwiches, salads, nuggets, waffle fries, and more.", "No", "Chick-Fil-A - Tangeman University Center, 2701 Bearcat Way", "Chick-fil-A", "ChickFilA" },
                    { 3, "Café", "Teachers Café offers a wide variety of grab ‘n go sandwiches, salads, fruit cups, parfaits and more. If you need a pick-me-up, we also serve Rooted Grounds coffee.", "Meal Exchange", "Teachers Café, 2610 University Circle", "Teachers Café", "TeachersCafé" },
                    { 4, "Café", "Bearcats Café, located in TUC offers both a grab and go style meal or a hot meal to go. \nBABB (Bad-Ass Breakfast Burritos) - Satisfy your early-morning or late-night cravings with burritos packed with premium meats, crispy potatoes, cheese, and eggs, all wrapped in a soft tortilla. Top it off with our addictive sauces for a truly satisfying meal. \nStuffed Sensation - Treat yourself to Otis Spunkmeyer cookies stuffed with irresistible fillings like Oreos® and Reese’s. These decadent cookies are sure to be a hit, whether served fresh or pre-packaged. \nTo the Max Mexican - Build a healthy, flavorful bowl or burrito at To The Max Mexican. Choose from fresh, authentically seasoned ingredients, carefully portioned for a balanced meal. \nAC BBQ - Enjoy rich, flavorful barbecue rooted in Black excellence and community, created by Anthony Anderson and Cedric the Entertainer. AC Barbeque brings people together with its delicious, culturally inspired dishes.", "Carryout and Limited Seating", "Bearcats Café - Tangeman University Center, 2701 Bearcat Way", "Bearcats Café", "BearcatsCafé" },
                    { 5, "Café", "Campus View Café offers a wide variety of grab ‘n go sandwiches, salads, fruit cups, parfaits and more. If you need a pick-me-up, we also serve Rooted Grounds coffee.", "Meal Exchange", "Campus View Café - University Hall, 51 Goodman Avenue - Medical Campus", "CampusView Café", "CampusViewCafé" },
                    { 6, "Resident Dining", "On the Green is an all-you-care-to-eat dining facility that boasts 8 dining stations, dishing up comfort food classics, made-to-order stir-fry and pasta, homemade soups, fresh salads with local greens, and in-house baked desserts. On the Green also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten as well as Simple Zone a “pantry” where food items needed by customers with celiac disease or food allergies can be housed with precautions against cross-contact can be found.", "Dine In", "On The Green - Marian Spencer Hall, 2911 Scioto Lane", "On the Green", "OTG" },
                    { 7, "Resident Dining", "MarketPointe is a 37,000 foot state-of-the-art dining facility that boasts 8 dining stations that put you at the center of a culinary food hall experience. From delicious, plant-forward dishes and nourishing made-to-order sandwiches to authentic global bowls and craveable Latin-infused flavors, MarketPointe has something for everyone. MarketPointe also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten. Cap your dining experience with a fresh-roasted cup of local Rooted Grounds coffee and something sweet.", "Dine In", "MarketPointe - Siddal Hall, 2580 Corbett Drive", "MarketPointe", "MarketPointe" },
                    { 8, "Retail Dining", "At The Halal Shack, our food is Made with Love. Our culture is rooted in Middle Eastern & Mediterranean heritage which embodies bonds that are created through sharing food Made With Love. Find us at Tangeman University Center.", "Meal Exchange after 2 P.M.", "The Halal Shack - Tangeman University Center, 2701 Bearcat Way", "Halal Shack", "HalalShack" },
                    { 9, "Retail Dining", "Pei Wei at Tangeman University Center offers authentic, Asian-inspired cuisine without compromising on quality or convenience.", "No", "Pei Wei - Tangeman University Center, 2701 Bearcat Way", "Pei Wei", "PeiWei" },
                    { 10, "CStore", "Market on Main is your mini-grocery store in the heart of campus! Water by the case, dairy, snacks, grab-and-go, heat-and-eat meals, beverages and more are available for all of your convenience needs.", "No", "Market on Main, 2820 Bearcat Way", "Market on Main", "MarketOnMain" },
                    { 11, "Resident Dining", "Center Court is an expansive all-you-care-to-eat facility that boasts over a dozen unique dining destinations to feed hungry Bearcats. Enjoy favorites like pizza, handhelds, Indian cuisine from Choolaah, and made-to-order handcrafted sandwiches to an expansive salad bar, homemade soups and indulgent desserts. Center Court also features Simple Servings, an allergen-friendly station committed to providing delicious, wholesome meals safely prepared free of 8 of the top allergens, plus gluten.", "Dine In", "Center Court - Campus Recreation Center, 2810 Woodside Drive", "Center Court", "CenterCourt" },
                    { 12, "Café", "DAAP Café serves your favorite breakfast, lunch, and dinner options. The Café also serves Simply to Go sandwiches, salads, & snacks for students who are hungry and on the go. If you need a pick-me-up, we also serve iced bubble tea and Rooted Grounds coffee.", "Meal Exchange", "DAAP Café @ Aronoff Center, 2624 Clifton Avenue", "DAAP Café", "DaapCafé" },
                    { 13, "Café", "Partnering with the local Pneuma Coffee Roasters, renowned for their commitment to quality, The 86 Coffee Bar offers an array of meticulously crafted brews, from rich espressos to velvety lattes. Moreover, the menu extends beyond traditional offerings, with specialty drinks inspired by the creativity of CCM's community.", "No", "College-Conservatory of Music, 2604 Backstage Drive", "The 86 Coffee Bar", "86Coffee" },
                    { 14, "CStore", "Salty and sweet snacks, grab-and-go salads, sandwiches, fruit cups, heat-and-eat meals, beverages and more are available at the Mainstreet Express Mart.", "No", "Tangeman University Center, 2701 Bearcat Way", "Mainstreet Express Mart", "Mainstreet" },
                    { 15, "Café", "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.", "No", "Starbucks @ Lindner Hall, 2906 Woodside Drive", "Starbucks - Linder", "Starbucks_Linder" },
                    { 16, "Café", "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.", "No", "Starbucks @ Langsam Library, 2911 Woodside Drive", "Starbucks - Langsam", "Starbucks_Langsam" },
                    { 17, "Resident Dining", "Stadium View Café features Sicilian pizza and a build-your-own rice bowl station. \nThe Café also serves an exclusive game day menu during football season.", "Dine In and Carryout", "Bearcats Café - Tangeman University Center, 2701 Bearcat Way", "Stadium View Café", "StadiumView" },
                    { 18, "Café", "Starbucks roasts high-quality whole bean coffees. Other premium beverage options include rich espressos, lattes, and Tazo Teas. Starbucks also serves a variety of pastries and confections.", "No", "Starbucks @ Medical Science Building, 234 Goodman Drive", "Starbucks - Medical Campus", "Starbucks_Medical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_DiningHallId",
                table: "Review",
                column: "DiningHallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_DiningHall_DiningHallId",
                table: "Review",
                column: "DiningHallId",
                principalTable: "DiningHall",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_DiningHall_DiningHallId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "DiningHall");

            migrationBuilder.DropIndex(
                name: "IX_Review_DiningHallId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "DiningHallId",
                table: "Review");
        }
    }
}
