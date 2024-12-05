using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorybaseApi.Migrations
{
    /// <inheritdoc />
    public partial class IndexingToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Purchases_UserId",
                table: "Purchases",
                newName: "IX_Purchase_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_LiteraryWorkId",
                table: "Purchases",
                newName: "IX_Purchase_LiteraryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_ChapterId",
                table: "Purchases",
                newName: "IX_Purchase_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_LiteraryWorks_WriterId",
                table: "LiteraryWorks",
                newName: "IX_LiteraryWork_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_UserId",
                table: "Bookmarks",
                newName: "IX_Bookmark_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmarks_LiteraryWorkId",
                table: "Bookmarks",
                newName: "IX_Bookmark_LiteraryWorkId");

            migrationBuilder.AlterColumn<string>(
                name: "Auth0UserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_User_Auth0UserId",
                table: "Users",
                column: "Auth0UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chapter_BookId",
                table: "Chapters",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Auth0UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Chapter_BookId",
                table: "Chapters");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_UserId",
                table: "Purchases",
                newName: "IX_Purchases_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_LiteraryWorkId",
                table: "Purchases",
                newName: "IX_Purchases_LiteraryWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_ChapterId",
                table: "Purchases",
                newName: "IX_Purchases_ChapterId");

            migrationBuilder.RenameIndex(
                name: "IX_LiteraryWork_WriterId",
                table: "LiteraryWorks",
                newName: "IX_LiteraryWorks_WriterId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_UserId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookmark_LiteraryWorkId",
                table: "Bookmarks",
                newName: "IX_Bookmarks_LiteraryWorkId");

            migrationBuilder.AlterColumn<string>(
                name: "Auth0UserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
