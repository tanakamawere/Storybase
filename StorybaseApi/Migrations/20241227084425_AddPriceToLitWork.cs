using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StorybaseApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToLitWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "LiteraryWorks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "LiteraryWorks");
        }
    }
}
