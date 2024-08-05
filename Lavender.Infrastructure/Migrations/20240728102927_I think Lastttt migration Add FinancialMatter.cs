using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IthinkLasttttmigrationAddFinancialMatter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductionManager_Salary",
                table: "LineType",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Worker_Wage_EachHour",
                table: "LineType",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "FinancialMatter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Executive_Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Executive_Profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Designer_Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tailor_Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialMatter", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialMatter");

            migrationBuilder.DropColumn(
                name: "ProductionManager_Salary",
                table: "LineType");

            migrationBuilder.DropColumn(
                name: "Worker_Wage_EachHour",
                table: "LineType");
        }
    }
}
