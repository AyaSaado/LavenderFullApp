using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsinLavander : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SItemType");

            migrationBuilder.DropColumn(
                name: "TypeOfUnit",
                table: "SItemType");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ItemSize");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PatternMaker_Sallary",
                table: "AspNetUsers",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "LName",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "ItemSizeWithColorId",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan",
                column: "ItemSizeWithColorId",
                principalTable: "ItemSizeWithColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan");

            migrationBuilder.RenameColumn(
                name: "Sallary",
                table: "AspNetUsers",
                newName: "PatternMaker_Sallary");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "LName");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SItemType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfUnit",
                table: "SItemType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemSizeWithColorId",
                table: "Plan",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ItemSize",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionEmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DaysOnly = table.Column<DateTime>(type: "date", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    WorkQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_AspNetUsers_ProductionEmpId",
                        column: x => x.ProductionEmpId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Work_ProductionEmpId",
                table: "Work",
                column: "ProductionEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                table: "Plan",
                column: "ItemSizeWithColorId",
                principalTable: "ItemSizeWithColor",
                principalColumn: "Id");
        }
    }
}
