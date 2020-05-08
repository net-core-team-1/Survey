using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class deletetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test_migration",
                schema: "Identity",
                table: "USERS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 115, DateTimeKind.Local).AddTicks(9939),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 856, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 168, DateTimeKind.Local).AddTicks(714),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 903, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 151, DateTimeKind.Local).AddTicks(7804),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 888, DateTimeKind.Local).AddTicks(9722));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 856, DateTimeKind.Local).AddTicks(738),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 115, DateTimeKind.Local).AddTicks(9939));

            migrationBuilder.AddColumn<int>(
                name: "test_migration",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 903, DateTimeKind.Local).AddTicks(2092),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 168, DateTimeKind.Local).AddTicks(714));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 888, DateTimeKind.Local).AddTicks(9722),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 26, 35, 151, DateTimeKind.Local).AddTicks(7804));
        }
    }
}
