using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewSummaryIdToVote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the Vote table if it does not exist
            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    ReviewSummaryId = table.Column<int>(nullable: true),
                    SelectedVote = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vote_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // User can be deleted, votes will be removed

                    table.ForeignKey(
                        name: "FK_Vote_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict); // Prevent cycle

                    table.ForeignKey(
                        name: "FK_Vote_ReviewSummary_ReviewSummaryId",
                        column: x => x.ReviewSummaryId,
                        principalTable: "ReviewSummary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict); // Prevent cycle
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_UserId",
                table: "Vote",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ReviewId",
                table: "Vote",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ReviewSummaryId",
                table: "Vote",
                column: "ReviewSummaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Vote");
        }
    }
}
