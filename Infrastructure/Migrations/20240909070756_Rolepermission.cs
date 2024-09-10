using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rolepermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionMaps_AspNetRoles_RoleId",
                table: "RolePermissionMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissionMaps_Permissions_PermissionId",
                table: "RolePermissionMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermissionMaps",
                table: "RolePermissionMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.RenameTable(
                name: "RolePermissionMaps",
                newName: "adm_RolePermissionMap");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "adm_Permission");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissionMaps_RoleId",
                table: "adm_RolePermissionMap",
                newName: "IX_adm_RolePermissionMap_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermissionMaps_PermissionId",
                table: "adm_RolePermissionMap",
                newName: "IX_adm_RolePermissionMap_PermissionId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "adm_Permission",
                newName: "DisplayOrder");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "adm_Permission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "adm_Permission",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CreatedBy",
                table: "adm_Permission",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "adm_Permission",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "adm_Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "adm_Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ModifiedBy",
                table: "adm_Permission",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "adm_Permission",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PermissionTypeId",
                table: "adm_Permission",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PermissionTypeMastersId",
                table: "adm_Permission",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_adm_RolePermissionMap",
                table: "adm_RolePermissionMap",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_adm_Permission",
                table: "adm_Permission",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_adm_Permission_PermissionTypeMastersId",
                table: "adm_Permission",
                column: "PermissionTypeMastersId");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_Permission_adm_Masters_PermissionTypeMastersId",
                table: "adm_Permission",
                column: "PermissionTypeMastersId",
                principalTable: "adm_Masters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_adm_RolePermissionMap_AspNetRoles_RoleId",
                table: "adm_RolePermissionMap",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_adm_RolePermissionMap_adm_Permission_PermissionId",
                table: "adm_RolePermissionMap",
                column: "PermissionId",
                principalTable: "adm_Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adm_Permission_adm_Masters_PermissionTypeMastersId",
                table: "adm_Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_RolePermissionMap_AspNetRoles_RoleId",
                table: "adm_RolePermissionMap");

            migrationBuilder.DropForeignKey(
                name: "FK_adm_RolePermissionMap_adm_Permission_PermissionId",
                table: "adm_RolePermissionMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adm_RolePermissionMap",
                table: "adm_RolePermissionMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_adm_Permission",
                table: "adm_Permission");

            migrationBuilder.DropIndex(
                name: "IX_adm_Permission_PermissionTypeMastersId",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "PermissionTypeId",
                table: "adm_Permission");

            migrationBuilder.DropColumn(
                name: "PermissionTypeMastersId",
                table: "adm_Permission");

            migrationBuilder.RenameTable(
                name: "adm_RolePermissionMap",
                newName: "RolePermissionMaps");

            migrationBuilder.RenameTable(
                name: "adm_Permission",
                newName: "Permissions");

            migrationBuilder.RenameIndex(
                name: "IX_adm_RolePermissionMap_RoleId",
                table: "RolePermissionMaps",
                newName: "IX_RolePermissionMaps_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_adm_RolePermissionMap_PermissionId",
                table: "RolePermissionMaps",
                newName: "IX_RolePermissionMaps_PermissionId");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Permissions",
                newName: "Priority");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermissionMaps",
                table: "RolePermissionMaps",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionMaps_AspNetRoles_RoleId",
                table: "RolePermissionMaps",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissionMaps_Permissions_PermissionId",
                table: "RolePermissionMaps",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
