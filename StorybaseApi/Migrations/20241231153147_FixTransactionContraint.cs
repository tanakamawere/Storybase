using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorybaseApi.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionContraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_Reference",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments",
                column: "TransactionId",
                unique: true,
                filter: "[TransactionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Reference",
                table: "Payments",
                column: "Reference",
                unique: true);
        }
    }
}
