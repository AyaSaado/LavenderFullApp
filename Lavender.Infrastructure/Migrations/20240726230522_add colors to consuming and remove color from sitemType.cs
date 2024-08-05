using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolorstoconsumingandremovecolorfromsitemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "SItemType");

            migrationBuilder.AddColumn<string>(
                name: "Colors",
                table: "Consuming",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Colors",
                table: "Consuming");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "SItemType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
