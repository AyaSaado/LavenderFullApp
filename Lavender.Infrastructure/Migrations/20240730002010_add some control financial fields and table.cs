using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addsomecontrolfinancialfieldsandtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LastTotalPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Item",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DisscountRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromQuantity = table.Column<int>(type: "int", nullable: false),
                    ToQuantity = table.Column<int>(type: "int", nullable: false),
                    Disscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinancialMattersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisscountRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisscountRange_FinancialMatter_FinancialMattersId",
                        column: x => x.FinancialMattersId,
                        principalTable: "FinancialMatter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisscountRange_FinancialMattersId",
                table: "DisscountRange",
                column: "FinancialMattersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisscountRange");

            migrationBuilder.DropColumn(
                name: "LastTotalPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Item");
        }
    }
}
