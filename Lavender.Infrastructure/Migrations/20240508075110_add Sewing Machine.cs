using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSewingMachine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    ProductionEmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelNameId = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyProduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "date", nullable: false),
                    WorkHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkQuantity = table.Column<int>(type: "int", nullable: false),
                    WorkerIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyProduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyProduction_SewingMachine_WorkerIdId",
                        column: x => x.WorkerIdId,
                        principalTable: "SewingMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProduction_WorkerIdId",
                table: "DailyProduction",
                column: "WorkerIdId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMachine_ModelNameId",
                table: "SewingMachine",
                column: "ModelNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMachine_ProductionEmpId",
                table: "SewingMachine",
                column: "ProductionEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyProduction");

            migrationBuilder.DropTable(
                name: "SewingMachine");

            migrationBuilder.DropTable(
                name: "ModelName");
        }
    }
}
