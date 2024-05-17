using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixselfjoininstep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Design_Order_OrderId",
                table: "Design");

            migrationBuilder.DropForeignKey(
                name: "FK_Step_Step_StepId",
                table: "Step");

            migrationBuilder.DropIndex(
                name: "IX_Step_StepId",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "Step");

            migrationBuilder.AddForeignKey(
                name: "FK_Design_Order_OrderId",
                table: "Design",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Design_Order_OrderId",
                table: "Design");

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "Step",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Step_StepId",
                table: "Step",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Design_Order_OrderId",
                table: "Design",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Step_Step_StepId",
                table: "Step",
                column: "StepId",
                principalTable: "Step",
                principalColumn: "Id");
        }
    }
}
