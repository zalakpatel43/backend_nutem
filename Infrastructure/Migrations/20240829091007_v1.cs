using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adm_CompanyMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_CompanyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_Masters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_NozzelMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NozzelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NozzelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_NozzelMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_ProductionOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ItemNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_ProductionOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_ProductMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ItemNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_ProductMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_ShiftMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_ShiftMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_TrailerInspection",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    InspectedById = table.Column<long>(type: "bigint", nullable: true),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfInspection = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleTypeId = table.Column<long>(type: "bigint", nullable: true),
                    LicensePlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruckNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleCleanAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleCleanNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComingOrderFromForeignAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComingOrderFromForeignNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorCloseProperlyAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoorCloseProperlyNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallIntegrityAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallIntegrityNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorInGoodConditionAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorInGoodConditionNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentOnTrailerAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentOnTrailerNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeWorkingOrderAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SafeWorkingOrderNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRustPresentAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRustPresentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureSettingUsedAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemperatureSettingUsedNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_TrailerInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_TrailerInspection_adm_CompanyMaster_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "adm_CompanyMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_TrailerInspection_adm_Masters_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "adm_Masters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_AttributeCheckHeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ACDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    BottleDateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWeightRange = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_AttributeCheckHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_AttributeCheckHeader_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_AttributeCheckHeader_adm_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_DowntimeTracking",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductLineId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SAPProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_DowntimeTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_DowntimeTracking_adm_Masters_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "adm_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_DowntimeTracking_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_DowntimeTracking_adm_ProductionOrder_SAPProductionOrderId",
                        column: x => x.SAPProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_WeightCheckHeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SAPProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ShiftId = table.Column<long>(type: "bigint", nullable: true),
                    BottleDateCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinWeightRange = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxWeightRange = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QAUserId = table.Column<long>(type: "bigint", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_WeightCheckHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckHeader_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckHeader_adm_ProductionOrder_SAPProductionOrderId",
                        column: x => x.SAPProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckHeader_adm_ShiftMaster_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "adm_ShiftMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                    UserId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
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
                    UserId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "RolePermissionMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false),
                    HasMasterAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissionMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermissionMaps_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissionMaps_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_AttributeCheckDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: true),
                    TDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsGoodCondition = table.Column<bool>(type: "bit", nullable: false),
                    CapTorque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmptyBottleWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotNoOfLiquid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    LeakTest = table.Column<int>(type: "int", nullable: false),
                    DoneByUserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneByUserNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_AttributeCheckDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_AttributeCheckDetails_adm_AttributeCheckHeader_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "adm_AttributeCheckHeader",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_CauseMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    DowntimeTrackingId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_CauseMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_CauseMaster_adm_DowntimeTracking_DowntimeTrackingId",
                        column: x => x.DowntimeTrackingId,
                        principalTable: "adm_DowntimeTracking",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_DowntimeTrackingDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseId = table.Column<long>(type: "bigint", nullable: false),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTakenId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_DowntimeTrackingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_DowntimeTrackingDetails_adm_DowntimeTracking_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "adm_DowntimeTracking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_WeightCheckDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: true),
                    TDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AvgWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DoneByUserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneByUserNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_WeightCheckDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckDetails_adm_WeightCheckHeader_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "adm_WeightCheckHeader",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_WeightCheckSubDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailId = table.Column<long>(type: "bigint", nullable: true),
                    NozzleId = table.Column<long>(type: "bigint", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_WeightCheckSubDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckSubDetails_adm_NozzelMaster_NozzleId",
                        column: x => x.NozzleId,
                        principalTable: "adm_NozzelMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_WeightCheckSubDetails_adm_WeightCheckDetails_DetailId",
                        column: x => x.DetailId,
                        principalTable: "adm_WeightCheckDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_adm_AttributeCheckDetails_HeaderId",
                table: "adm_AttributeCheckDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_AttributeCheckHeader_ProductId",
                table: "adm_AttributeCheckHeader",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_AttributeCheckHeader_ProductionOrderId",
                table: "adm_AttributeCheckHeader",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_CauseMaster_DowntimeTrackingId",
                table: "adm_CauseMaster",
                column: "DowntimeTrackingId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_DowntimeTracking_ProductId",
                table: "adm_DowntimeTracking",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_DowntimeTracking_ProductLineId",
                table: "adm_DowntimeTracking",
                column: "ProductLineId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_DowntimeTracking_SAPProductionOrderId",
                table: "adm_DowntimeTracking",
                column: "SAPProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_DowntimeTrackingDetails_HeaderId",
                table: "adm_DowntimeTrackingDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerInspection_CompanyId",
                table: "adm_TrailerInspection",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerInspection_VehicleTypeId",
                table: "adm_TrailerInspection",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckDetails_HeaderId",
                table: "adm_WeightCheckDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckHeader_ProductId",
                table: "adm_WeightCheckHeader",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckHeader_SAPProductionOrderId",
                table: "adm_WeightCheckHeader",
                column: "SAPProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckHeader_ShiftId",
                table: "adm_WeightCheckHeader",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckSubDetails_DetailId",
                table: "adm_WeightCheckSubDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_WeightCheckSubDetails_NozzleId",
                table: "adm_WeightCheckSubDetails",
                column: "NozzleId");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionMaps_PermissionId",
                table: "RolePermissionMaps",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissionMaps_RoleId",
                table: "RolePermissionMaps",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm_AttributeCheckDetails");

            migrationBuilder.DropTable(
                name: "adm_CauseMaster");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTrackingDetails");

            migrationBuilder.DropTable(
                name: "adm_TrailerInspection");

            migrationBuilder.DropTable(
                name: "adm_WeightCheckSubDetails");

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
                name: "RolePermissionMaps");

            migrationBuilder.DropTable(
                name: "adm_AttributeCheckHeader");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTracking");

            migrationBuilder.DropTable(
                name: "adm_CompanyMaster");

            migrationBuilder.DropTable(
                name: "adm_NozzelMaster");

            migrationBuilder.DropTable(
                name: "adm_WeightCheckDetails");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "adm_Masters");

            migrationBuilder.DropTable(
                name: "adm_WeightCheckHeader");

            migrationBuilder.DropTable(
                name: "adm_ProductMaster");

            migrationBuilder.DropTable(
                name: "adm_ProductionOrder");

            migrationBuilder.DropTable(
                name: "adm_ShiftMaster");
        }
    }
}
