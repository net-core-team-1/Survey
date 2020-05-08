using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 856, DateTimeKind.Local).AddTicks(738),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000));

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
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 888, DateTimeKind.Local).AddTicks(9722),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 856, DateTimeKind.Local).AddTicks(738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 903, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 22, 16, 15, 14, 888, DateTimeKind.Local).AddTicks(9722));
        }
    }
}
