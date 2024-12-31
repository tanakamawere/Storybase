using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorybaseApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPaynowReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PollUrl",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PayNowReference",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaynowReference",
                table: "Payments",
                column: "PayNowReference");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PollUrl",
                table: "Payments",
                column: "PollUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_PaynowReference",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PollUrl",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PayNowReference",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "PollUrl",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
