using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_adm_ProductInstructionDetails_ProductMasterId",
                table: "adm_ProductInstructionDetails",
                column: "ProductMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationAdjustmentDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationChecklistDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationSpecificationDetails");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparationInstructionDetails");

            migrationBuilder.DropTable(
                name: "adm_StartEndBatchChecklist");

            migrationBuilder.DropTable(
                name: "adm_QCTSpecificationMaster");

            migrationBuilder.DropTable(
                name: "adm_LiquidPreparation");

            migrationBuilder.DropTable(
                name: "adm_MaterialMaster");

            migrationBuilder.DropTable(
                name: "adm_ProductInstructionDetails");

            migrationBuilder.DropTable(
                name: "adm_TankMaster");
        }
    }
}
