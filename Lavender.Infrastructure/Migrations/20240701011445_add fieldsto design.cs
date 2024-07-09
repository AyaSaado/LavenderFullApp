using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldstodesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Design",
                newName: "Description");

            migrationBuilder.AddColumn<decimal>(
                name: "DesignPrice",
                table: "Design",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesignPrice",
                table: "Design");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Design",
                newName: "Title");
        }
    }
}
