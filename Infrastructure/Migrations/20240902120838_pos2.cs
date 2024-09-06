using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductMaster_ProductMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.DropIndex(
                name: "IX_adm_PostCheckList_ProductMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.DropIndex(
                name: "IX_adm_PostCheckList_ShiftMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.DropColumn(
                name: "ProductMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.DropColumn(
                name: "ShiftMasterId",
                table: "adm_PostCheckList");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_FillingLine",
                table: "adm_PostCheckList",
                column: "FillingLine");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ProductId",
                table: "adm_PostCheckList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ShiftId",
                table: "adm_PostCheckList",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_Masters_FillingLine",
                table: "adm_PostCheckList",
                column: "FillingLine",
                principalTable: "adm_Masters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductMaster_ProductId",
                table: "adm_PostCheckList",
                column: "ProductId",
                principalTable: "adm_ProductMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftId",
                table: "adm_PostCheckList",
                column: "ShiftId",
                principalTable: "adm_ShiftMaster",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_Masters_FillingLine",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductMaster_ProductId",
                table: "adm_PostCheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftId",
                table: "adm_PostCheckList");

            migrationBuilder.DropIndex(
                name: "IX_adm_PostCheckList_FillingLine",
                table: "adm_PostCheckList");

            migrationBuilder.DropIndex(
                name: "IX_adm_PostCheckList_ProductId",
                table: "adm_PostCheckList");

            migrationBuilder.DropIndex(
                name: "IX_adm_PostCheckList_ShiftId",
                table: "adm_PostCheckList");

            migrationBuilder.AddColumn<long>(
                name: "ProductMasterId",
                table: "adm_PostCheckList",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShiftMasterId",
                table: "adm_PostCheckList",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ProductMasterId",
                table: "adm_PostCheckList",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_adm_PostCheckList_ShiftMasterId",
                table: "adm_PostCheckList",
                column: "ShiftMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_ProductMaster_ProductMasterId",
                table: "adm_PostCheckList",
                column: "ProductMasterId",
                principalTable: "adm_ProductMaster",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_PostCheckList_adm_ShiftMaster_ShiftMasterId",
                table: "adm_PostCheckList",
                column: "ShiftMasterId",
                principalTable: "adm_ShiftMaster",
                principalColumn: "Id");
        }
    }
}
