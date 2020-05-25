using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingentityintoUserentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 140, DateTimeKind.Local).AddTicks(5032),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 47, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                schema: "Identity",
                table: "USERS",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 186, DateTimeKind.Local).AddTicks(6655),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 89, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 247, DateTimeKind.Local).AddTicks(265),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 136, DateTimeKind.Local).AddTicks(2981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 171, DateTimeKind.Local).AddTicks(6882),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 75, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 214, DateTimeKind.Local).AddTicks(3669),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 115, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 235, DateTimeKind.Local).AddTicks(239),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 128, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.CreateIndex(
                name: "IX_USERS_EntityId",
                schema: "Identity",
                table: "USERS",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_USERS_ENTITIES_EntityId",
                schema: "Identity",
                table: "USERS",
                column: "EntityId",
                principalSchema: "Identity",
                principalTable: "ENTITIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERS_ENTITIES_EntityId",
                schema: "Identity",
                table: "USERS");

            migrationBuilder.DropIndex(
                name: "IX_USERS_EntityId",
                schema: "Identity",
                table: "USERS");

            migrationBuilder.DropColumn(
                name: "EntityId",
                schema: "Identity",
                table: "USERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 47, DateTimeKind.Local).AddTicks(3158),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 140, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 89, DateTimeKind.Local).AddTicks(6375),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 186, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 136, DateTimeKind.Local).AddTicks(2981),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 247, DateTimeKind.Local).AddTicks(265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 75, DateTimeKind.Local).AddTicks(7168),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 171, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 115, DateTimeKind.Local).AddTicks(4328),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 214, DateTimeKind.Local).AddTicks(3669));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 128, DateTimeKind.Local).AddTicks(328),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 0, 5, 39, 235, DateTimeKind.Local).AddTicks(239));
        }
    }
}
