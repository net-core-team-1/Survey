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
                defaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 908, DateTimeKind.Local).AddTicks(1808),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 960, DateTimeKind.Local).AddTicks(6628),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 944, DateTimeKind.Local).AddTicks(5245),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 188, DateTimeKind.Local).AddTicks(7000),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 908, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 235, DateTimeKind.Local).AddTicks(8001),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 960, DateTimeKind.Local).AddTicks(6628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 6, 19, 43, 14, 221, DateTimeKind.Local).AddTicks(131),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 19, 14, 22, 24, 944, DateTimeKind.Local).AddTicks(5245));
        }
    }
}
