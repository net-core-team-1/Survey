using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class changingonDeletebahvior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROLES_FEATURES_FEATURES_FeatureId",
                schema: "Identity",
                table: "ROLES_FEATURES");

            migrationBuilder.DropForeignKey(
                name: "FK_ROLES_FEATURES_ROLES_RoleId",
                schema: "Identity",
                table: "ROLES_FEATURES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLES_ROLES_RoleId",
                schema: "Identity",
                table: "USERS_ROLES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLES_USERS_UserId",
                schema: "Identity",
                table: "USERS_ROLES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 914, DateTimeKind.Local).AddTicks(6291),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 140, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 956, DateTimeKind.Local).AddTicks(8056),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 186, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 31, 5, DateTimeKind.Local).AddTicks(9082),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 247, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 942, DateTimeKind.Local).AddTicks(5728),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 171, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 984, DateTimeKind.Local).AddTicks(58),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 214, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 997, DateTimeKind.Local).AddTicks(5573),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 235, DateTimeKind.Local).AddTicks(239));

            migrationBuilder.AddForeignKey(
                name: "FK_ROLES_FEATURES_FEATURES_FeatureId",
                schema: "Identity",
                table: "ROLES_FEATURES",
                column: "FeatureId",
                principalSchema: "Identity",
                principalTable: "FEATURES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ROLES_FEATURES_ROLES_RoleId",
                schema: "Identity",
                table: "ROLES_FEATURES",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLES_ROLES_RoleId",
                schema: "Identity",
                table: "USERS_ROLES",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLES_USERS_UserId",
                schema: "Identity",
                table: "USERS_ROLES",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROLES_FEATURES_FEATURES_FeatureId",
                schema: "Identity",
                table: "ROLES_FEATURES");

            migrationBuilder.DropForeignKey(
                name: "FK_ROLES_FEATURES_ROLES_RoleId",
                schema: "Identity",
                table: "ROLES_FEATURES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLES_ROLES_RoleId",
                schema: "Identity",
                table: "USERS_ROLES");

            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ROLES_USERS_UserId",
                schema: "Identity",
                table: "USERS_ROLES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 140, DateTimeKind.Local).AddTicks(5032),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 914, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 186, DateTimeKind.Local).AddTicks(6655),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 956, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 247, DateTimeKind.Local).AddTicks(265),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 31, 5, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 171, DateTimeKind.Local).AddTicks(6882),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 942, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 214, DateTimeKind.Local).AddTicks(3669),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 984, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 235, DateTimeKind.Local).AddTicks(239),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 997, DateTimeKind.Local).AddTicks(5573));

            migrationBuilder.AddForeignKey(
                name: "FK_ROLES_FEATURES_FEATURES_FeatureId",
                schema: "Identity",
                table: "ROLES_FEATURES",
                column: "FeatureId",
                principalSchema: "Identity",
                principalTable: "FEATURES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ROLES_FEATURES_ROLES_RoleId",
                schema: "Identity",
                table: "ROLES_FEATURES",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLES_ROLES_RoleId",
                schema: "Identity",
                table: "USERS_ROLES",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ROLES_USERS_UserId",
                schema: "Identity",
                table: "USERS_ROLES",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
