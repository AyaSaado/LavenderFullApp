using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldnameinproductionemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sallary",
                table: "AspNetUsers",
                newName: "PatternMaker_Salary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PatternMaker_Salary",
                table: "AspNetUsers",
                newName: "Sallary");
        }
    }
}
