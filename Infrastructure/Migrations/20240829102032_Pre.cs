using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Pre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    ProductMasterId = table.Column<long>(type: "bigint", nullable: true),
                    ShiftMasterId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adm_PreCheckList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_ProductMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "adm_ProductMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_adm_PreCheckList_adm_ShiftMaster_ShiftMasterId",
                        column: x => x.ShiftMasterId,
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
                name: "IX_adm_PreCheckList_PrePostQuestionId",
                table: "adm_PreCheckList",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_ProductMasterId",
                table: "adm_PreCheckList",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckList_ShiftMasterId",
                table: "adm_PreCheckList",
                column: "ShiftMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckListDetails_PreCheckListId",
                table: "adm_PreCheckListDetails",
                column: "PreCheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PreCheckListDetails_PrePostQuestionId",
                table: "adm_PreCheckListDetails",
                column: "PrePostQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PrePostQuestion_PreCheckListEntityId",
                table: "adm_PrePostQuestion",
                column: "PreCheckListEntityId");

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
                name: "FK_adm_PreCheckList_adm_PrePostQuestion_PrePostQuestionId",
                table: "adm_PreCheckList");

            migrationBuilder.DropTable(
                name: "adm_CauseMaster");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTrackingDetails");

            migrationBuilder.DropTable(
                name: "adm_PreCheckListDetails");

            migrationBuilder.DropTable(
                name: "adm_DowntimeTracking");

            migrationBuilder.DropTable(
                name: "adm_Masters");

            migrationBuilder.DropTable(
                name: "adm_PrePostQuestion");

            migrationBuilder.DropTable(
                name: "adm_PreCheckList");
        }
    }
}
