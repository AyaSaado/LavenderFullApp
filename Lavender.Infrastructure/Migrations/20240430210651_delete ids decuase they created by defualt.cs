using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteidsdecuasetheycreatedbydefualt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionEmp_Id",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "StoreItem_Id",
                table: "SItemType");

            migrationBuilder.DropColumn(
                name: "Stype_Id",
                table: "SItemType");

            migrationBuilder.DropColumn(
                name: "Factory_Id",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "SItemType_Id",
                table: "Purchase");

            migrationBuilder.DropColumn(
                name: "Step_Id",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Actor_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ItemType_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Item_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DesigningSection_Id",
                table: "MakertSection");

            migrationBuilder.DropColumn(
                name: "PatternMaker_Id",
                table: "MakertSection");

            migrationBuilder.DropColumn(
                name: "ItemSize_Id",
                table: "ItemSizeWithColor");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "ItemSize");

            migrationBuilder.DropColumn(
                name: "Designer_Id",
                table: "InspirationImage");

            migrationBuilder.DropColumn(
                name: "Design_Id",
                table: "FabricDesign");

            migrationBuilder.DropColumn(
                name: "FabricType_Id",
                table: "FabricDesign");

            migrationBuilder.DropColumn(
                name: "Design_Id",
                table: "DesignImage");

            migrationBuilder.DropColumn(
                name: "Accessory_Id",
                table: "DesignAccessory");

            migrationBuilder.DropColumn(
                name: "Design_Id",
                table: "DesignAccessory");

            migrationBuilder.DropColumn(
                name: "Designer_Id",
                table: "Design");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "Design");

            migrationBuilder.DropColumn(
                name: "ProductionLine_Id",
                table: "Design");

            migrationBuilder.DropColumn(
                name: "Tailor_Id",
                table: "Design");

            migrationBuilder.DropColumn(
                name: "Design_Id",
                table: "Consuming");

            migrationBuilder.DropColumn(
                name: "SItemType_Id",
                table: "Consuming");

            migrationBuilder.DropColumn(
                name: "Design_Id",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "Head_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LineType_Id",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionEmp_Id",
                table: "Work",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreItem_Id",
                table: "SItemType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stype_Id",
                table: "SItemType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Factory_Id",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SItemType_Id",
                table: "Purchase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Step_Id",
                table: "Plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Actor_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemType_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Item_Id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesigningSection_Id",
                table: "MakertSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatternMaker_Id",
                table: "MakertSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemSize_Id",
                table: "ItemSizeWithColor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "ItemSize",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Designer_Id",
                table: "InspirationImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design_Id",
                table: "FabricDesign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FabricType_Id",
                table: "FabricDesign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design_Id",
                table: "DesignImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Accessory_Id",
                table: "DesignAccessory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design_Id",
                table: "DesignAccessory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Designer_Id",
                table: "Design",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "Design",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionLine_Id",
                table: "Design",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tailor_Id",
                table: "Design",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design_Id",
                table: "Consuming",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SItemType_Id",
                table: "Consuming",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Design_Id",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Head_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineType_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
