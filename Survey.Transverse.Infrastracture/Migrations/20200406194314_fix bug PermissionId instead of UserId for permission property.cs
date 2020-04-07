using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class fixbugPermissionIdinsteadofUserIdforpermissionproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_PERMISSIONS_PERMISSIONS_UserId",
                schema: "Identity",
                table: "USER_PERMISSIONS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "USERS",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 4, 6, 11, 40, 43, 490, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "PERMISSIONS",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001),
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "FEATURES",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131),
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_PERMISSIONS_PERMISSIONS_PermissionId",
                schema: "Identity",
                table: "USER_PERMISSIONS",
                column: "PermissionId",
                principalSchema: "Identity",
                principalTable: "PERMISSIONS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_PERMISSIONS_PERMISSIONS_PermissionId",
                schema: "Identity",
                table: "USER_PERMISSIONS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "USERS",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 4, 6, 11, 40, 43, 490, DateTimeKind.Local).AddTicks(9935),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "PERMISSIONS",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeletedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletReason",
                schema: "Identity",
                table: "FEATURES",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_PERMISSIONS_PERMISSIONS_UserId",
                schema: "Identity",
                table: "USER_PERMISSIONS",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "PERMISSIONS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
