using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class deletecodefromentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 631, DateTimeKind.Local).AddTicks(2657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 723, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 644, DateTimeKind.Local).AddTicks(6606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 892, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 673, DateTimeKind.Local).AddTicks(3574),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 936, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 637, DateTimeKind.Local).AddTicks(9063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 858, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 670, DateTimeKind.Local).AddTicks(9134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 930, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OUTBOX_MESSAGES",
                nullable: false,
                defaultValue: new Guid("0e5259c7-273b-4599-ac63-85295f01f9e5"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("04d21804-b82f-4c64-bdff-2ce802f8950e"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 723, DateTimeKind.Local).AddTicks(5621),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 631, DateTimeKind.Local).AddTicks(2657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 892, DateTimeKind.Local).AddTicks(792),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 644, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 936, DateTimeKind.Local).AddTicks(5903),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 673, DateTimeKind.Local).AddTicks(3574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 858, DateTimeKind.Local).AddTicks(1800),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 637, DateTimeKind.Local).AddTicks(9063));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 930, DateTimeKind.Local).AddTicks(5185),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 29, 19, 54, 55, 670, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Identity",
                table: "ENTITIES",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OUTBOX_MESSAGES",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("04d21804-b82f-4c64-bdff-2ce802f8950e"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("0e5259c7-273b-4599-ac63-85295f01f9e5"));
        }
    }
}
