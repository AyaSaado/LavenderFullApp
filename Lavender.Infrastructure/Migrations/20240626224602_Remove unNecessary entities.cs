using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveunNecessaryentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesignAccessory");

            migrationBuilder.DropTable(
                name: "FabricDesign");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "FabricType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TypeOfUnit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignAccessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignAccessory_Accessory_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesignAccessory_Design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FabricDesign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignId = table.Column<int>(type: "int", nullable: false),
                    FabricTypeId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FabricWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricDesign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricDesign_Design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FabricDesign_FabricType_FabricTypeId",
                        column: x => x.FabricTypeId,
                        principalTable: "FabricType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesignAccessory_AccessoryId",
                table: "DesignAccessory",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignAccessory_DesignId",
                table: "DesignAccessory",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricDesign_DesignId",
                table: "FabricDesign",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricDesign_FabricTypeId",
                table: "FabricDesign",
                column: "FabricTypeId");
        }
    }
}
