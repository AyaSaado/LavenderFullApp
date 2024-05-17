using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lavender.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesigningSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesigningSection", x => x.Id);
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
                name: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Step_StepId",
                        column: x => x.StepId,
                        principalTable: "Step",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoreItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: true),
                    NationalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: true),
                    PatternMaker_Sallary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sallary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Head_Id = table.Column<int>(type: "int", nullable: true),
                    LineType_Id = table.Column<int>(type: "int", nullable: true),
                    HeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LineTypeId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_HeadId",
                        column: x => x.HeadId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_LineType_LineTypeId",
                        column: x => x.LineTypeId,
                        principalTable: "LineType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SItemType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stype_Id = table.Column<int>(type: "int", nullable: false),
                    StoreItem_Id = table.Column<int>(type: "int", nullable: false),
                    STypeId = table.Column<int>(type: "int", nullable: false),
                    StoreItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SItemType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SItemType_SType_STypeId",
                        column: x => x.STypeId,
                        principalTable: "SType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SItemType_StoreItem_StoreItemId",
                        column: x => x.StoreItemId,
                        principalTable: "StoreItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspirationImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designer_Id = table.Column<int>(type: "int", nullable: false),
                    DesignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspirationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspirationImage_AspNetUsers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MakertSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatternMaker_Id = table.Column<int>(type: "int", nullable: false),
                    DesigningSection_Id = table.Column<int>(type: "int", nullable: false),
                    PatternMakerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesigningSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakertSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakertSection_AspNetUsers_PatternMakerId",
                        column: x => x.PatternMakerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MakertSection_DesigningSection_DesigningSectionId",
                        column: x => x.DesigningSectionId,
                        principalTable: "DesigningSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    ItemType_Id = table.Column<int>(type: "int", nullable: false),
                    Actor_Id = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_ActorId",
                        column: x => x.ActorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysOnly = table.Column<DateTime>(type: "date", nullable: false),
                    ProductionEmp_Id = table.Column<int>(type: "int", nullable: false),
                    WorkHours = table.Column<int>(type: "int", nullable: false),
                    WorkQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductionEmpId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Work_AspNetUsers_ProductionEmpId",
                        column: x => x.ProductionEmpId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostOfUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SItemType_Id = table.Column<int>(type: "int", nullable: false),
                    Factory_Id = table.Column<int>(type: "int", nullable: false),
                    SItemTypeId = table.Column<int>(type: "int", nullable: false),
                    FactoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Factory_FactoryId",
                        column: x => x.FactoryId,
                        principalTable: "Factory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_SItemType_SItemTypeId",
                        column: x => x.SItemTypeId,
                        principalTable: "SItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionLine_Id = table.Column<int>(type: "int", nullable: false),
                    Tailor_Id = table.Column<int>(type: "int", nullable: false),
                    Designer_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    ProductionLineId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TailorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DesignerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Design_AspNetUsers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Design_AspNetUsers_ProductionLineId",
                        column: x => x.ProductionLineId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Design_AspNetUsers_TailorId",
                        column: x => x.TailorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Design_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSize_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaidMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Design_Id = table.Column<int>(type: "int", nullable: false),
                    ChatType = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consuming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Design_Id = table.Column<int>(type: "int", nullable: false),
                    QuantityOrdered = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfDemand = table.Column<DateTime>(type: "date", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false),
                    SItemType_Id = table.Column<int>(type: "int", nullable: false),
                    SItemTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consuming", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consuming_Design_DesignId",
                        column: x => x.DesignId,
                        principalTable: "Design",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consuming_SItemType_SItemTypeId",
                        column: x => x.SItemTypeId,
                        principalTable: "SItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesignAccessory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfUnit = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accessory_Id = table.Column<int>(type: "int", nullable: false),
                    Design_Id = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false)
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
                name: "DesignImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageType = table.Column<int>(type: "int", nullable: false),
                    Design_Id = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesignImage_Design_DesignId",
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
                    FabricWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FabricHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FabricType_Id = table.Column<int>(type: "int", nullable: false),
                    Design_Id = table.Column<int>(type: "int", nullable: false),
                    FabricTypeId = table.Column<int>(type: "int", nullable: false),
                    DesignId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ItemSizeWithColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ItemSize_Id = table.Column<int>(type: "int", nullable: false),
                    ItemSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSizeWithColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSizeWithColor_ItemSize_ItemSizeId",
                        column: x => x.ItemSizeId,
                        principalTable: "ItemSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender_Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false),
                    Chat_Id = table.Column<int>(type: "int", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_Chat_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Step_Id = table.Column<int>(type: "int", nullable: false),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ItemSizeWithColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_ItemSizeWithColor_ItemSizeWithColorId",
                        column: x => x.ItemSizeWithColorId,
                        principalTable: "ItemSizeWithColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plan_Step_StepId",
                        column: x => x.StepId,
                        principalTable: "Step",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HeadId",
                table: "AspNetUsers",
                column: "HeadId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LineTypeId",
                table: "AspNetUsers",
                column: "LineTypeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_DesignId",
                table: "Chat",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Consuming_DesignId",
                table: "Consuming",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_Consuming_SItemTypeId",
                table: "Consuming",
                column: "SItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_DesignerId",
                table: "Design",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_OrderId",
                table: "Design",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_ProductionLineId",
                table: "Design",
                column: "ProductionLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_TailorId",
                table: "Design",
                column: "TailorId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignAccessory_AccessoryId",
                table: "DesignAccessory",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignAccessory_DesignId",
                table: "DesignAccessory",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_DesignImage_DesignId",
                table: "DesignImage",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricDesign_DesignId",
                table: "FabricDesign",
                column: "DesignId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricDesign_FabricTypeId",
                table: "FabricDesign",
                column: "FabricTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspirationImage_DesignerId",
                table: "InspirationImage",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSize_OrderId",
                table: "ItemSize",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSizeWithColor_ItemSizeId",
                table: "ItemSizeWithColor",
                column: "ItemSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_MakertSection_DesigningSectionId",
                table: "MakertSection",
                column: "DesigningSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MakertSection_PatternMakerId",
                table: "MakertSection",
                column: "PatternMakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatId",
                table: "Message",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ActorId",
                table: "Order",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemId",
                table: "Order",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemTypeId",
                table: "Order",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_ItemSizeWithColorId",
                table: "Plan",
                column: "ItemSizeWithColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_StepId",
                table: "Plan",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_FactoryId",
                table: "Purchase",
                column: "FactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_SItemTypeId",
                table: "Purchase",
                column: "SItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SItemType_StoreItemId",
                table: "SItemType",
                column: "StoreItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SItemType_STypeId",
                table: "SItemType",
                column: "STypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_StepId",
                table: "Step",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_ProductionEmpId",
                table: "Work",
                column: "ProductionEmpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consuming");

            migrationBuilder.DropTable(
                name: "DesignAccessory");

            migrationBuilder.DropTable(
                name: "DesignImage");

            migrationBuilder.DropTable(
                name: "FabricDesign");

            migrationBuilder.DropTable(
                name: "InspirationImage");

            migrationBuilder.DropTable(
                name: "MakertSection");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "FabricType");

            migrationBuilder.DropTable(
                name: "DesigningSection");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "ItemSizeWithColor");

            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Factory");

            migrationBuilder.DropTable(
                name: "SItemType");

            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "ItemSize");

            migrationBuilder.DropTable(
                name: "SType");

            migrationBuilder.DropTable(
                name: "StoreItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "LineType");
        }
    }
}
