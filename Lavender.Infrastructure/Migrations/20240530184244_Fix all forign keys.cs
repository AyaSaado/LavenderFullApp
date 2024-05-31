using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fixallforignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProduction_SewingMachine_WorkerIdId",
                table: "DailyProduction");

            migrationBuilder.RenameColumn(
                name: "WorkerIdId",
                table: "DailyProduction",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyProduction_WorkerIdId",
                table: "DailyProduction",
                newName: "IX_DailyProduction_WorkerId");

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

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "DailyProduction",
                newName: "WorkerIdId");

            migrationBuilder.RenameIndex(
                name: "IX_DailyProduction_WorkerId",
                table: "DailyProduction",
                newName: "IX_DailyProduction_WorkerIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProduction_SewingMachine_WorkerIdId",
                table: "DailyProduction",
                column: "WorkerIdId",
                principalTable: "SewingMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
