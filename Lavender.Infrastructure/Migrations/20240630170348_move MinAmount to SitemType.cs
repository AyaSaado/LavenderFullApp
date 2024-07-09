using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class moveMinAmounttoSitemType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "StoreItem");

            migrationBuilder.AddColumn<decimal>(
                name: "MinAmount",
                table: "SItemType",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "SItemType");

            migrationBuilder.AddColumn<decimal>(
                name: "MinAmount",
                table: "StoreItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
