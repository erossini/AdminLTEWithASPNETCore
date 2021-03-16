using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PSC.Repositories.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audit_AzureCostImportLogs",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzureCostImportId = table.Column<long>(type: "bigint", nullable: false),
                    LogData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_AzureCostImportLogs", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_AzureCostImports",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_AzureCostImports", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_AzureCosts",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceId = table.Column<long>(type: "bigint", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    ResourceGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    SubcategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AzureCostImportId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(24,20)", precision: 24, scale: 20, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(24,20)", precision: 24, scale: 20, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_AzureCosts", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_AzureCategories",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_AzureCategories", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_AzureLocations",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_AzureLocations", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_AzureResourceGroups",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_AzureResourceGroups", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_AzureResources",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_AzureResources", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_AzureSubcategories",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_AzureSubcategories", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Audit_tbl_Countries",
                columns: table => new
                {
                    AuditId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AuditAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit_tbl_Countries", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "AzureCostImports",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureCostImports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AzureCategories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AzureCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AzureLocations",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AzureLocations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AzureResourceGroups",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AzureResourceGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AzureResources",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AzureResources", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_AzureSubcategories",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AzureSubcategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Countries",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Countries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AzureCostImportLogs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AzureCostImportId = table.Column<long>(type: "bigint", nullable: false),
                    LogData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogType = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureCostImportLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AzureCostImportLogs_AzureCostImports_AzureCostImportId",
                        column: x => x.AzureCostImportId,
                        principalTable: "AzureCostImports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AzureCosts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceId = table.Column<long>(type: "bigint", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    ResourceGroupId = table.Column<long>(type: "bigint", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    SubcategoryId = table.Column<long>(type: "bigint", nullable: true),
                    AzureCostImportId = table.Column<long>(type: "bigint", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(24,20)", precision: 24, scale: 20, nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(24,20)", precision: 24, scale: 20, nullable: false),
                    ImportDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzureCosts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AzureCosts_AzureCostImports_AzureCostImportId",
                        column: x => x.AzureCostImportId,
                        principalTable: "AzureCostImports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzureCosts_tbl_AzureCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbl_AzureCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzureCosts_tbl_AzureLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tbl_AzureLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzureCosts_tbl_AzureResourceGroups_ResourceGroupId",
                        column: x => x.ResourceGroupId,
                        principalTable: "tbl_AzureResourceGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzureCosts_tbl_AzureResources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "tbl_AzureResources",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzureCosts_tbl_AzureSubcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "tbl_AzureSubcategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 3, 16, 10, 38, 41, 126, DateTimeKind.Local).AddTicks(238), null, null, null, "Afghanistan", 0 },
                    { 126L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5297), null, null, null, "Netherlands", 0 },
                    { 127L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5303), null, null, null, "New Zealand", 0 },
                    { 128L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5309), null, null, null, "Nicaragua", 0 },
                    { 129L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5315), null, null, null, "Niger", 0 },
                    { 130L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5322), null, null, null, "Nigeria", 0 },
                    { 131L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5328), null, null, null, "Norway", 0 },
                    { 132L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5334), null, null, null, "Oman", 0 },
                    { 133L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5340), null, null, null, "Pakistan", 0 },
                    { 134L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5346), null, null, null, "Palau", 0 },
                    { 125L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5291), null, null, null, "Nepal", 0 },
                    { 135L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5352), null, null, null, "Panama", 0 },
                    { 137L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5364), null, null, null, "Paraguay", 0 },
                    { 138L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5421), null, null, null, "Peru", 0 },
                    { 139L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5429), null, null, null, "Philippines", 0 },
                    { 140L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5435), null, null, null, "Poland", 0 },
                    { 141L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5441), null, null, null, "Portugal", 0 },
                    { 142L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5447), null, null, null, "Qatar", 0 },
                    { 143L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5454), null, null, null, "Romania", 0 },
                    { 144L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5460), null, null, null, "Russia", 0 },
                    { 145L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5466), null, null, null, "Rwanda", 0 },
                    { 136L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5358), null, null, null, "Papua New Guinea", 0 },
                    { 124L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5285), null, null, null, "Nauru", 0 },
                    { 123L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5279), null, null, null, "Namibia", 0 },
                    { 122L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5272), null, null, null, "Myanmar (Burma)", 0 },
                    { 101L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5143), null, null, null, "Liechtenstein", 0 },
                    { 102L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5150), null, null, null, "Lithuania", 0 },
                    { 103L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5156), null, null, null, "Luxembourg", 0 },
                    { 104L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5162), null, null, null, "Macedonia", 0 },
                    { 105L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5168), null, null, null, "Madagascar", 0 },
                    { 106L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5174), null, null, null, "Malawi", 0 },
                    { 107L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5180), null, null, null, "Malaysia", 0 },
                    { 108L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5186), null, null, null, "Maldives", 0 },
                    { 109L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5192), null, null, null, "Mali", 0 },
                    { 110L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5199), null, null, null, "Malta", 0 },
                    { 111L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5205), null, null, null, "Marshall Islands", 0 },
                    { 112L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5211), null, null, null, "Mauritania", 0 },
                    { 113L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5217), null, null, null, "Mauritius", 0 },
                    { 114L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5223), null, null, null, "Mexico", 0 },
                    { 115L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5230), null, null, null, "Micronesia, Federated States of", 0 },
                    { 116L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5236), null, null, null, "Moldova", 0 },
                    { 117L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5242), null, null, null, "Monaco", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 118L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5248), null, null, null, "Mongolia", 0 },
                    { 119L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5254), null, null, null, "Montenegro", 0 },
                    { 120L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5260), null, null, null, "Morocco", 0 },
                    { 121L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5266), null, null, null, "Mozambique", 0 },
                    { 146L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5472), null, null, null, "Saint Kitts and Nevis", 0 },
                    { 100L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5137), null, null, null, "Libya", 0 },
                    { 147L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5478), null, null, null, "Saint Lucia", 0 },
                    { 149L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5491), null, null, null, "Samoa", 0 },
                    { 175L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5650), null, null, null, "Thailand", 0 },
                    { 176L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5656), null, null, null, "Togo", 0 },
                    { 177L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5663), null, null, null, "Tonga", 0 },
                    { 178L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5669), null, null, null, "Trinidad and Tobago", 0 },
                    { 179L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5675), null, null, null, "Tunisia", 0 },
                    { 180L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5681), null, null, null, "Turkey", 0 },
                    { 181L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5687), null, null, null, "Turkmenistan", 0 },
                    { 182L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5693), null, null, null, "Tuvalu", 0 },
                    { 183L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5699), null, null, null, "Uganda", 0 },
                    { 174L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5644), null, null, null, "Tanzania", 0 },
                    { 184L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5705), null, null, null, "Ukraine", 0 },
                    { 186L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5717), null, null, null, "United Kingdom", 1 },
                    { 187L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6808), null, null, null, "United States of America", 1 },
                    { 188L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6833), null, null, null, "Uruguay", 0 },
                    { 189L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6839), null, null, null, "Uzbekistan", 0 },
                    { 190L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6846), null, null, null, "Vanuatu", 0 },
                    { 191L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6852), null, null, null, "Vatican City (Holy See)", 0 },
                    { 192L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6858), null, null, null, "Venezuela", 0 },
                    { 193L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6864), null, null, null, "Vietnam", 0 },
                    { 194L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6870), null, null, null, "Yemen", 0 },
                    { 185L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5711), null, null, null, "United Arab Emirates", 0 },
                    { 173L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5638), null, null, null, "Tajikistan", 0 },
                    { 172L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5632), null, null, null, "Taiwan", 0 },
                    { 171L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5626), null, null, null, "Syria", 0 },
                    { 150L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5497), null, null, null, "San Marino", 0 },
                    { 151L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5503), null, null, null, "Sao Tome and Principe", 0 },
                    { 152L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5509), null, null, null, "Saudi Arabia", 0 },
                    { 153L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5515), null, null, null, "Senegal", 0 },
                    { 154L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5521), null, null, null, "Serbia", 0 },
                    { 155L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5527), null, null, null, "Seychelles", 0 },
                    { 156L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5534), null, null, null, "Sierra Leone", 0 },
                    { 157L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5540), null, null, null, "Singapore", 0 },
                    { 158L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5546), null, null, null, "Slovakia", 0 },
                    { 159L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5552), null, null, null, "Slovenia", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 160L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5558), null, null, null, "Solomon Islands", 0 },
                    { 161L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5565), null, null, null, "Somalia", 0 },
                    { 162L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5571), null, null, null, "South Africa", 0 },
                    { 163L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5577), null, null, null, "South Sudan", 0 },
                    { 164L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5583), null, null, null, "Spain", 0 },
                    { 165L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5589), null, null, null, "Sri Lanka", 0 },
                    { 166L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5595), null, null, null, "Sudan", 0 },
                    { 167L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5601), null, null, null, "Suriname", 0 },
                    { 168L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5607), null, null, null, "Swaziland", 0 },
                    { 169L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5614), null, null, null, "Sweden", 0 },
                    { 170L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5620), null, null, null, "Switzerland", 0 },
                    { 148L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5484), null, null, null, "Saint Vincent and the Grenadines", 0 },
                    { 99L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5131), null, null, null, "Liberia", 0 },
                    { 98L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5125), null, null, null, "Lesotho", 0 },
                    { 97L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5118), null, null, null, "Lebanon", 0 },
                    { 27L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4486), null, null, null, "Burkina Faso", 0 },
                    { 28L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4493), null, null, null, "Burundi", 0 },
                    { 29L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4499), null, null, null, "Cambodia", 0 },
                    { 30L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4505), null, null, null, "Cameroon", 0 },
                    { 31L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4511), null, null, null, "Canada", 0 },
                    { 32L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4518), null, null, null, "Cape Verde", 0 },
                    { 33L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4524), null, null, null, "Central African Republic", 0 },
                    { 34L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4530), null, null, null, "Chad", 0 },
                    { 35L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4536), null, null, null, "Chile", 0 },
                    { 26L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4473), null, null, null, "Bulgaria", 0 },
                    { 36L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4735), null, null, null, "China", 0 },
                    { 38L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4751), null, null, null, "Comoros", 0 },
                    { 39L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4757), null, null, null, "Congo, Republic of the", 0 },
                    { 40L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4763), null, null, null, "Congo, Democratic Republic of the", 0 },
                    { 41L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4769), null, null, null, "Costa Rica", 0 },
                    { 42L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4776), null, null, null, "Cote d'Ivoire", 0 },
                    { 43L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4783), null, null, null, "Croatia", 0 },
                    { 44L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4789), null, null, null, "Cuba", 0 },
                    { 45L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4795), null, null, null, "Cyprus", 0 },
                    { 46L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4802), null, null, null, "Czech Republic", 0 },
                    { 37L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4744), null, null, null, "Colombia", 0 },
                    { 25L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4467), null, null, null, "Brunei", 0 },
                    { 24L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4461), null, null, null, "Brazil", 0 },
                    { 23L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4455), null, null, null, "Botswana", 0 },
                    { 2L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4220), null, null, null, "Albania", 0 },
                    { 3L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4312), null, null, null, "Algeria", 0 },
                    { 4L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4321), null, null, null, "Andorra", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 5L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4328), null, null, null, "Angola", 0 },
                    { 6L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4334), null, null, null, "Antigua and Barbuda", 0 },
                    { 7L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4341), null, null, null, "Argentina", 0 },
                    { 8L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4347), null, null, null, "Armenia", 0 },
                    { 9L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4353), null, null, null, "Australia", 0 },
                    { 10L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4359), null, null, null, "Austria", 0 },
                    { 11L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4366), null, null, null, "Azerbaijan", 0 },
                    { 12L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4372), null, null, null, "The Bahamas", 0 },
                    { 13L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4378), null, null, null, "Bahrain", 0 },
                    { 14L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4385), null, null, null, "Bangladesh", 0 },
                    { 15L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4391), null, null, null, "Barbados", 0 },
                    { 16L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4411), null, null, null, "Belarus", 0 },
                    { 17L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4417), null, null, null, "Belgium", 0 },
                    { 18L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4424), null, null, null, "Belize", 0 },
                    { 19L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4430), null, null, null, "Benin", 0 },
                    { 20L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4436), null, null, null, "Bhutan", 0 },
                    { 21L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4443), null, null, null, "Bolivia", 0 },
                    { 22L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4449), null, null, null, "Bosnia and Herzegovina", 0 },
                    { 47L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4808), null, null, null, "Denmark", 0 },
                    { 48L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4814), null, null, null, "Djibouti", 0 },
                    { 49L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4820), null, null, null, "Dominica", 0 },
                    { 50L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4826), null, null, null, "Dominican Republic", 0 },
                    { 76L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4988), null, null, null, "Iceland", 0 },
                    { 77L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4995), null, null, null, "India", 0 },
                    { 78L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5001), null, null, null, "Indonesia", 0 },
                    { 79L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5007), null, null, null, "Iran", 0 },
                    { 80L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5013), null, null, null, "Iraq", 0 },
                    { 81L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5019), null, null, null, "Ireland", 0 },
                    { 82L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5025), null, null, null, "Israel", 0 },
                    { 83L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5031), null, null, null, "Italy", 0 },
                    { 84L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5038), null, null, null, "Jamaica", 0 },
                    { 85L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5044), null, null, null, "Japan", 0 },
                    { 86L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5050), null, null, null, "Jordan", 0 },
                    { 87L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5056), null, null, null, "Kazakhstan", 0 },
                    { 88L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5062), null, null, null, "Kenya", 0 },
                    { 89L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5069), null, null, null, "Kiribati", 0 },
                    { 90L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5075), null, null, null, "Korea, North", 0 },
                    { 91L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5081), null, null, null, "Korea, South", 0 },
                    { 92L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5088), null, null, null, "Kosovo", 0 },
                    { 93L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5094), null, null, null, "Kuwait", 0 },
                    { 94L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5100), null, null, null, "Kyrgyzstan", 0 },
                    { 95L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5106), null, null, null, "Laos", 0 }
                });

            migrationBuilder.InsertData(
                table: "tbl_Countries",
                columns: new[] { "ID", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Order" },
                values: new object[,]
                {
                    { 96L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(5112), null, null, null, "Latvia", 0 },
                    { 75L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4982), null, null, null, "Hungary", 0 },
                    { 195L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6877), null, null, null, "Zambia", 0 },
                    { 74L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4976), null, null, null, "Honduras", 0 },
                    { 72L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4964), null, null, null, "Guyana", 0 },
                    { 51L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4832), null, null, null, "East Timor (Timor-Leste)", 0 },
                    { 52L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4838), null, null, null, "Ecuador", 0 },
                    { 53L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4846), null, null, null, "Egypt", 0 },
                    { 54L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4852), null, null, null, "El Salvador", 0 },
                    { 55L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4858), null, null, null, "Equatorial Guinea", 0 },
                    { 56L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4864), null, null, null, "Eritrea", 0 },
                    { 57L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4870), null, null, null, "Estonia", 0 },
                    { 58L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4876), null, null, null, "Ethiopia", 0 },
                    { 59L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4883), null, null, null, "Fiji", 0 },
                    { 60L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4889), null, null, null, "Finland", 0 },
                    { 61L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4895), null, null, null, "France", 0 },
                    { 62L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4901), null, null, null, "Gabon", 0 },
                    { 63L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4908), null, null, null, "The Gambia", 0 },
                    { 64L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4914), null, null, null, "Georgia", 0 },
                    { 65L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4920), null, null, null, "Germany", 0 },
                    { 66L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4926), null, null, null, "Ghana", 0 },
                    { 67L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4933), null, null, null, "Greece", 0 },
                    { 68L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4939), null, null, null, "Grenada", 0 },
                    { 69L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4945), null, null, null, "Guatemala", 0 },
                    { 70L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4951), null, null, null, "Guinea", 0 },
                    { 71L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4958), null, null, null, "Guinea-Bissau", 0 },
                    { 73L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(4970), null, null, null, "Haiti", 0 },
                    { 196L, new DateTime(2021, 3, 16, 10, 38, 41, 131, DateTimeKind.Local).AddTicks(6883), null, null, null, "Zimbabwe", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AzureCostImportLogs_AzureCostImportId",
                table: "AzureCostImportLogs",
                column: "AzureCostImportId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_AzureCostImportId",
                table: "AzureCosts",
                column: "AzureCostImportId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_CategoryId",
                table: "AzureCosts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_LocationId",
                table: "AzureCosts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_ResourceGroupId",
                table: "AzureCosts",
                column: "ResourceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_ResourceId",
                table: "AzureCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureCosts_SubcategoryId",
                table: "AzureCosts",
                column: "SubcategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit_AzureCostImportLogs");

            migrationBuilder.DropTable(
                name: "Audit_AzureCostImports");

            migrationBuilder.DropTable(
                name: "Audit_AzureCosts");

            migrationBuilder.DropTable(
                name: "Audit_tbl_AzureCategories");

            migrationBuilder.DropTable(
                name: "Audit_tbl_AzureLocations");

            migrationBuilder.DropTable(
                name: "Audit_tbl_AzureResourceGroups");

            migrationBuilder.DropTable(
                name: "Audit_tbl_AzureResources");

            migrationBuilder.DropTable(
                name: "Audit_tbl_AzureSubcategories");

            migrationBuilder.DropTable(
                name: "Audit_tbl_Countries");

            migrationBuilder.DropTable(
                name: "AzureCostImportLogs");

            migrationBuilder.DropTable(
                name: "AzureCosts");

            migrationBuilder.DropTable(
                name: "tbl_Countries");

            migrationBuilder.DropTable(
                name: "AzureCostImports");

            migrationBuilder.DropTable(
                name: "tbl_AzureCategories");

            migrationBuilder.DropTable(
                name: "tbl_AzureLocations");

            migrationBuilder.DropTable(
                name: "tbl_AzureResourceGroups");

            migrationBuilder.DropTable(
                name: "tbl_AzureResources");

            migrationBuilder.DropTable(
                name: "tbl_AzureSubcategories");
        }
    }
}
