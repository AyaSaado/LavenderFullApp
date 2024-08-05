using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class reRemovetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelName",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Productivity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingMachine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModelNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductionEmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMachine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMachine_AspNetUsers_ProductionEmpId",
                        column: x => x.ProductionEmpId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingMachine_ModelName_ModelNameId",
                        column: x => x.ModelNameId,
                        principalTable: "ModelName",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_WorkerId",
                table: "DailyProduction",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMachine_ModelNameId",
                table: "SewingMachine",
                column: "ModelNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMachine_ProductionEmpId",
                table: "SewingMachine",
                column: "ProductionEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProduction_SewingMachine_WorkerId",
                table: "DailyProduction",
                column: "WorkerId",
                principalTable: "SewingMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProduction_SewingMachine_WorkerId",
                table: "DailyProduction");

            migrationBuilder.DropTable(
                name: "SewingMachine");

            migrationBuilder.DropTable(
                name: "ModelName");

            migrationBuilder.DropIndex(
                name: "IX_DailyProduction_WorkerId",
                table: "DailyProduction");
        }
    }
}
