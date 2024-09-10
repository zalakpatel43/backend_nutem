using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class beta2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "adm_WeightCheckHeader");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "adm_WeightCheckHeader");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "adm_PreCheckList");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "adm_PreCheckList");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "adm_PostCheckList");

            migrationBuilder.DropColumn(
                name: "ShiftName",
                table: "adm_PostCheckList");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "adm_AttributeCheckHeader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "adm_WeightCheckHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "adm_WeightCheckHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "adm_PreCheckList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "adm_PreCheckList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "adm_PostCheckList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShiftName",
                table: "adm_PostCheckList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "adm_AttributeCheckHeader",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
