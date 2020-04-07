using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class initproject2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 4, 6, 11, 40, 43, 490, DateTimeKind.Local).AddTicks(9935),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 273, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 327, DateTimeKind.Local).AddTicks(1415));

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 321, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 305, DateTimeKind.Local).AddTicks(6432));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 273, DateTimeKind.Local).AddTicks(4960),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 4, 6, 11, 40, 43, 490, DateTimeKind.Local).AddTicks(9935));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DisabledOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: true,
                defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 327, DateTimeKind.Local).AddTicks(1415),
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DisabledBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 321, DateTimeKind.Local).AddTicks(8171),
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"),
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 305, DateTimeKind.Local).AddTicks(6432),
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260"),
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
