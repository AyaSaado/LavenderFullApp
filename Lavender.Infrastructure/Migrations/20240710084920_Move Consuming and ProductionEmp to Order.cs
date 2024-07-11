using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveConsumingandProductionEmptoOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consuming_Design_DesignId",
                table: "Consuming");

            migrationBuilder.DropForeignKey(
                name: "FK_Design_AspNetUsers_ProductionLineId",
                table: "Design");

            migrationBuilder.DropIndex(
                name: "IX_Design_ProductionLineId",
                table: "Design");

            migrationBuilder.DropColumn(
                name: "ProductionLineId",
                table: "Design");

            migrationBuilder.RenameColumn(
                name: "DesignId",
                table: "Consuming",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Consuming_DesignId",
                table: "Consuming",
                newName: "IX_Consuming_OrderId");

            migrationBuilder.AddColumn<bool>(
                name: "IsFabric",
                table: "StoreItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductionLineId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductionLineId",
                table: "Order",
                column: "ProductionLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consuming_Order_OrderId",
                table: "Consuming",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ProductionLineId",
                table: "Order",
                column: "ProductionLineId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consuming_Order_OrderId",
                table: "Consuming");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ProductionLineId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductionLineId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsFabric",
                table: "StoreItem");

            migrationBuilder.DropColumn(
                name: "ProductionLineId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Consuming",
                newName: "DesignId");

            migrationBuilder.RenameIndex(
                name: "IX_Consuming_OrderId",
                table: "Consuming",
                newName: "IX_Consuming_DesignId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductionLineId",
                table: "Design",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Design_ProductionLineId",
                table: "Design",
                column: "ProductionLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consuming_Design_DesignId",
                table: "Consuming",
                column: "DesignId",
                principalTable: "Design",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Design_AspNetUsers_ProductionLineId",
                table: "Design",
                column: "ProductionLineId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
