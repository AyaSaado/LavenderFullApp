using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtypeofunit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeOfUnit",
                table: "SItemType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfUnit",
                table: "Consuming",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfUnit",
                table: "SItemType");

            migrationBuilder.DropColumn(
                name: "TypeOfUnit",
                table: "Consuming");
        }
    }
}
