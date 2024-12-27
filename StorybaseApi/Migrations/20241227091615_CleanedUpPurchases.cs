using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorybaseApi.Migrations
{
    /// <inheritdoc />
    public partial class CleanedUpPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Chapters_ChapterId",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_ChapterId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "ChapterId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PurchaseType",
                table: "Purchases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChapterId",
                table: "Purchases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseType",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ChapterId",
                table: "Purchases",
                column: "ChapterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Chapters_ChapterId",
                table: "Purchases",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id");
        }
    }
}
