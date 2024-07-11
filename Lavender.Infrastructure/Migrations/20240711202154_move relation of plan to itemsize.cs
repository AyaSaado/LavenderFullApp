using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class moverelationofplantoitemsize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "ItemSizeWithColorId",
                table: "Plan",
                newName: "ItemSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_ItemSizeWithColorId",
                table: "Plan",
                newName: "IX_Plan_ItemSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_ItemSize_ItemSizeId",
                table: "Plan",
                column: "ItemSizeId",
                principalTable: "ItemSize",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_ItemSize_ItemSizeId",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "ItemSizeId",
                table: "Plan",
                newName: "ItemSizeWithColorId");

            migrationBuilder.RenameIndex(
                name: "IX_Plan_ItemSizeId",
                table: "Plan",
                newName: "IX_Plan_ItemSizeWithColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan",
                column: "ItemSizeWithColorId",
                principalTable: "ItemSizeWithColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
