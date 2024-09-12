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
                name: "adm_MaterialMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_MaterialMaster", x => x.Id);
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
                name: "adm_Permission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    PermissionTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_Permission", x => x.Id);
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
                name: "adm_QCTSpecificationMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HighValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_QCTSpecificationMaster", x => x.Id);
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
                name: "adm_StartEndBatchChecklist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_StartEndBatchChecklist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "adm_TankMaster",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_TankMaster", x => x.Id);
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
                name: "adm_ProductInstructionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductMasterId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_ProductInstructionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_ProductInstructionDetails_adm_ProductMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "adm_ProductMaster",
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
                    ShiftMasterId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_adm_DowntimeTracking_adm_ShiftMaster_ShiftMasterId",
                        column: x => x.ShiftMasterId,
                        principalTable: "adm_ShiftMaster",
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
                name: "adm_LiquidPreparation",
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
                    BatchLotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankId = table.Column<long>(type: "bigint", nullable: true),
                    CompounderUserId = table.Column<long>(type: "bigint", nullable: true),
                    StandardBatchWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnalysisDoneByIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleReceivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleTestedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_LiquidPreparation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparation_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparation_adm_ProductionOrder_SAPProductionOrderId",
                        column: x => x.SAPProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparation_adm_ShiftMaster_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "adm_ShiftMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparation_adm_TankMaster_TankId",
                        column: x => x.TankId,
                        principalTable: "adm_TankMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_RolePermissionMap",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionId = table.Column<long>(type: "bigint", nullable: false),
                    HasMasterAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_RolePermissionMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_RolePermissionMap_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_RolePermissionMap_adm_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "adm_Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "adm_PalletPackingHeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SAPProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    FinishedCasesOnIncompletePalletAtStart = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinishedCasesOnIncompletePalletAtEnd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCasesProduced = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SupervisedBy = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PalletPackingHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PalletPackingHeader_AspNetUsers_SupervisedBy",
                        column: x => x.SupervisedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adm_PalletPackingHeader_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PalletPackingHeader_adm_ProductionOrder_SAPProductionOrderId",
                        column: x => x.SAPProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_TrailerLoadingHeader",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TLDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoorNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BOLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisedBy = table.Column<long>(type: "bigint", nullable: true),
                    SupervisedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_TrailerLoadingHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_TrailerLoadingHeader_AspNetUsers_SupervisedBy",
                        column: x => x.SupervisedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_adm_TrailerLoadingHeader_adm_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
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
                    CauseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneByUserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoneByUserNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "adm_LiquidPreparationChecklistDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidPreparationId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<long>(type: "bigint", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TankId = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartEndBatchChecklistId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_LiquidPreparationChecklistDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationChecklistDetails_adm_LiquidPreparation_LiquidPreparationId",
                        column: x => x.LiquidPreparationId,
                        principalTable: "adm_LiquidPreparation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationChecklistDetails_adm_StartEndBatchChecklist_StartEndBatchChecklistId",
                        column: x => x.StartEndBatchChecklistId,
                        principalTable: "adm_StartEndBatchChecklist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationChecklistDetails_adm_TankMaster_TankId",
                        column: x => x.TankId,
                        principalTable: "adm_TankMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_LiquidPreparationInstructionDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidPreparationId = table.Column<long>(type: "bigint", nullable: true),
                    InstructionId = table.Column<long>(type: "bigint", nullable: true),
                    MaterialId = table.Column<long>(type: "bigint", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WeightAdded = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DoneByIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_LiquidPreparationInstructionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationInstructionDetails_adm_LiquidPreparation_LiquidPreparationId",
                        column: x => x.LiquidPreparationId,
                        principalTable: "adm_LiquidPreparation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationInstructionDetails_adm_MaterialMaster_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "adm_MaterialMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationInstructionDetails_adm_ProductInstructionDetails_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "adm_ProductInstructionDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_LiquidPreparationSpecificationDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidPreparationId = table.Column<long>(type: "bigint", nullable: true),
                    SpecificationLimitId = table.Column<long>(type: "bigint", nullable: true),
                    Test1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Test2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnalysisDoneByIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SampleReceivedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SampleTestedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_LiquidPreparationSpecificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationSpecificationDetails_adm_LiquidPreparation_LiquidPreparationId",
                        column: x => x.LiquidPreparationId,
                        principalTable: "adm_LiquidPreparation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationSpecificationDetails_adm_QCTSpecificationMaster_SpecificationLimitId",
                        column: x => x.SpecificationLimitId,
                        principalTable: "adm_QCTSpecificationMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_PalletPackingDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: true),
                    PalletNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DoneByIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PalletPackingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PalletPackingDetails_adm_PalletPackingHeader_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "adm_PalletPackingHeader",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_TrailerLoadingDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    PalletQty = table.Column<int>(type: "int", nullable: false),
                    ProductionOrder = table.Column<long>(type: "bigint", nullable: true),
                    ActionTakenBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_TrailerLoadingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_TrailerLoadingDetails_adm_ProductionOrder_ProductionOrder",
                        column: x => x.ProductionOrder,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_TrailerLoadingDetails_adm_TrailerLoadingHeader_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "adm_TrailerLoadingHeader",
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

            migrationBuilder.CreateTable(
                name: "adm_LiquidPreparationAdjustmentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidPreparationId = table.Column<long>(type: "bigint", nullable: true),
                    MaterialId = table.Column<long>(type: "bigint", nullable: true),
                    LiquidPreparationInstructionId = table.Column<long>(type: "bigint", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Adjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LiquidPreparationInstructionDetailsId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_LiquidPreparationAdjustmentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationAdjustmentDetails_adm_LiquidPreparationInstructionDetails_LiquidPreparationInstructionDetailsId",
                        column: x => x.LiquidPreparationInstructionDetailsId,
                        principalTable: "adm_LiquidPreparationInstructionDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationAdjustmentDetails_adm_LiquidPreparation_LiquidPreparationId",
                        column: x => x.LiquidPreparationId,
                        principalTable: "adm_LiquidPreparation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_LiquidPreparationAdjustmentDetails_adm_MaterialMaster_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "adm_MaterialMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_PostCheckList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ShiftId = table.Column<long>(type: "bigint", nullable: true),
                    FillingLine = table.Column<long>(type: "bigint", nullable: true),
                    FillerUserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PrePostQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PostCheckList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PostCheckList_adm_Masters_FillingLine",
                        column: x => x.FillingLine,
                        principalTable: "adm_Masters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PostCheckList_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PostCheckList_adm_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "adm_ShiftMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_PostCheckListDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PostCheckListId = table.Column<long>(type: "bigint", nullable: false),
                    PrePostQuestionId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PostCheckListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PostCheckListDetails_adm_PostCheckList_PostCheckListId",
                        column: x => x.PostCheckListId,
                        principalTable: "adm_PostCheckList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "adm_PreCheckList",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionOrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ShiftId = table.Column<long>(type: "bigint", nullable: true),
                    FillingLine = table.Column<long>(type: "bigint", nullable: true),
                    FillerUserIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PrePostQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PreCheckList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_Masters_FillingLine",
                        column: x => x.FillingLine,
                        principalTable: "adm_Masters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_ProductMaster_ProductId",
                        column: x => x.ProductId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_ProductionOrder_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "adm_ProductionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_ShiftMaster_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "adm_ShiftMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_PrePostQuestion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    PostCheckListEntityId = table.Column<long>(type: "bigint", nullable: true),
                    PreCheckListEntityId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PrePostQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PrePostQuestion_adm_PostCheckList_PostCheckListEntityId",
                        column: x => x.PostCheckListEntityId,
                        principalTable: "adm_PostCheckList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PrePostQuestion_adm_PreCheckList_PreCheckListEntityId",
                        column: x => x.PreCheckListEntityId,
                        principalTable: "adm_PreCheckList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "adm_PreCheckListDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false),
                    Answer = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PreCheckListId = table.Column<long>(type: "bigint", nullable: false),
                    PrePostQuestionId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PreCheckListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PreCheckListDetails_adm_PreCheckList_PreCheckListId",
                        column: x => x.PreCheckListId,
                        principalTable: "adm_PreCheckList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_adm_PreCheckListDetails_adm_PrePostQuestion_PrePostQuestionId",
                        column: x => x.PrePostQuestionId,
                        principalTable: "adm_PrePostQuestion",
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
                name: "IX_adm_DowntimeTracking_ShiftMasterId",
                table: "adm_DowntimeTracking",
                column: "ShiftMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_DowntimeTrackingDetails_HeaderId",
                table: "adm_DowntimeTrackingDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparation_ProductId",
                table: "adm_LiquidPreparation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparation_SAPProductionOrderId",
                table: "adm_LiquidPreparation",
                column: "SAPProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparation_ShiftId",
                table: "adm_LiquidPreparation",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparation_TankId",
                table: "adm_LiquidPreparation",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationAdjustmentDetails_LiquidPreparationId",
                table: "adm_LiquidPreparationAdjustmentDetails",
                column: "LiquidPreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationAdjustmentDetails_LiquidPreparationInstructionDetailsId",
                table: "adm_LiquidPreparationAdjustmentDetails",
                column: "LiquidPreparationInstructionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationAdjustmentDetails_MaterialId",
                table: "adm_LiquidPreparationAdjustmentDetails",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationChecklistDetails_LiquidPreparationId",
                table: "adm_LiquidPreparationChecklistDetails",
                column: "LiquidPreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationChecklistDetails_StartEndBatchChecklistId",
                table: "adm_LiquidPreparationChecklistDetails",
                column: "StartEndBatchChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationChecklistDetails_TankId",
                table: "adm_LiquidPreparationChecklistDetails",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationInstructionDetails_InstructionId",
                table: "adm_LiquidPreparationInstructionDetails",
                column: "InstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationInstructionDetails_LiquidPreparationId",
                table: "adm_LiquidPreparationInstructionDetails",
                column: "LiquidPreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationInstructionDetails_MaterialId",
                table: "adm_LiquidPreparationInstructionDetails",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationSpecificationDetails_LiquidPreparationId",
                table: "adm_LiquidPreparationSpecificationDetails",
                column: "LiquidPreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_LiquidPreparationSpecificationDetails_SpecificationLimitId",
                table: "adm_LiquidPreparationSpecificationDetails",
                column: "SpecificationLimitId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PalletPackingDetails_HeaderId",
                table: "adm_PalletPackingDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PalletPackingHeader_ProductId",
                table: "adm_PalletPackingHeader",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PalletPackingHeader_SAPProductionOrderId",
                table: "adm_PalletPackingHeader",
                column: "SAPProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PalletPackingHeader_SupervisedBy",
                table: "adm_PalletPackingHeader",
                column: "SupervisedBy");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_FillingLine",
                table: "adm_PostCheckList",
                column: "FillingLine");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_PrePostQuestionId",
                table: "adm_PostCheckList",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ProductId",
                table: "adm_PostCheckList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ProductionOrderId",
                table: "adm_PostCheckList",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ShiftId",
                table: "adm_PostCheckList",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckListDetails_PostCheckListId",
                table: "adm_PostCheckListDetails",
                column: "PostCheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckListDetails_PrePostQuestionId",
                table: "adm_PostCheckListDetails",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_FillingLine",
                table: "adm_PreCheckList",
                column: "FillingLine");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_PrePostQuestionId",
                table: "adm_PreCheckList",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_ProductId",
                table: "adm_PreCheckList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_ProductionOrderId",
                table: "adm_PreCheckList",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_ShiftId",
                table: "adm_PreCheckList",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckListDetails_PreCheckListId",
                table: "adm_PreCheckListDetails",
                column: "PreCheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckListDetails_PrePostQuestionId",
                table: "adm_PreCheckListDetails",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PrePostQuestion_PostCheckListEntityId",
                table: "adm_PrePostQuestion",
                column: "PostCheckListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PrePostQuestion_PreCheckListEntityId",
                table: "adm_PrePostQuestion",
                column: "PreCheckListEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_ProductInstructionDetails_ProductMasterId",
                table: "adm_ProductInstructionDetails",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_RolePermissionMap_PermissionId",
                table: "adm_RolePermissionMap",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_RolePermissionMap_RoleId",
                table: "adm_RolePermissionMap",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerInspection_CompanyId",
                table: "adm_TrailerInspection",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerInspection_VehicleTypeId",
                table: "adm_TrailerInspection",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerLoadingDetails_HeaderId",
                table: "adm_TrailerLoadingDetails",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerLoadingDetails_ProductionOrder",
                table: "adm_TrailerLoadingDetails",
                column: "ProductionOrder");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerLoadingHeader_ProductionOrderId",
                table: "adm_TrailerLoadingHeader",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_TrailerLoadingHeader_SupervisedBy",
                table: "adm_TrailerLoadingHeader",
                column: "SupervisedBy");

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

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PostCheckList",
                column: "PrePostQuestionId",
                principalTable: "adm_PrePostQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckListDetails_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PostCheckListDetails",
                column: "PrePostQuestionId",
                principalTable: "adm_PrePostQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PreCheckList_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PreCheckList",
                column: "PrePostQuestionId",
                principalTable: "adm_PrePostQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductMaster_ProductId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PreCheckList_adm_ProductMaster_ProductId",
                table: "adm_PreCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductionOrder_ProductionOrderId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PreCheckList_adm_ProductionOrder_ProductionOrderId",
                table: "adm_PreCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_Masters_FillingLine",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PreCheckList_adm_Masters_FillingLine",
                table: "adm_PreCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PreCheckList_adm_ShiftMaster_ShiftId",
                table: "adm_PreCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PreCheckList_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PreCheckList");

            migrationBuilder.DropTable(
                name: "adm_AttributeCheckDetails");

            migrationBuilder.DropTable(
                name: "adm_CauseMaster");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTrackingDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationAdjustmentDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationChecklistDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationSpecificationDetails");

            migrationBuilder.DropTable(
                name: "adm_PalletPackingDetails");

            migrationBuilder.DropTable(
                name: "adm_PostCheckListDetails");

            migrationBuilder.DropTable(
                name: "adm_PreCheckListDetails");

            migrationBuilder.DropTable(
                name: "adm_RolePermissionMap");

            migrationBuilder.DropTable(
                name: "adm_TrailerInspection");

            migrationBuilder.DropTable(
                name: "adm_TrailerLoadingDetails");

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
                name: "adm_AttributeCheckHeader");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTracking");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationInstructionDetails");

            migrationBuilder.DropTable(
                name: "adm_StartEndBatchChecklist");

            migrationBuilder.DropTable(
                name: "adm_QCTSpecificationMaster");

            migrationBuilder.DropTable(
                name: "adm_PalletPackingHeader");

            migrationBuilder.DropTable(
                name: "adm_Permission");

            migrationBuilder.DropTable(
                name: "adm_CompanyMaster");

            migrationBuilder.DropTable(
                name: "adm_TrailerLoadingHeader");

            migrationBuilder.DropTable(
                name: "adm_NozzelMaster");

            migrationBuilder.DropTable(
                name: "adm_WeightCheckDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparation");

            migrationBuilder.DropTable(
                name: "adm_MaterialMaster");

            migrationBuilder.DropTable(
                name: "adm_ProductInstructionDetails");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "adm_WeightCheckHeader");

            migrationBuilder.DropTable(
                name: "adm_TankMaster");

            migrationBuilder.DropTable(
                name: "adm_ProductMaster");

            migrationBuilder.DropTable(
                name: "adm_ProductionOrder");

            migrationBuilder.DropTable(
                name: "adm_Masters");

            migrationBuilder.DropTable(
                name: "adm_ShiftMaster");

            migrationBuilder.DropTable(
                name: "adm_PrePostQuestion");

            migrationBuilder.DropTable(
                name: "adm_PostCheckList");

            migrationBuilder.DropTable(
                name: "adm_PreCheckList");
        }
    }
}
