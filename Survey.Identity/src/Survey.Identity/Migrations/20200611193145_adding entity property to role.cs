using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingentitypropertytorole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 723, DateTimeKind.Local).AddTicks(5621),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 243, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 892, DateTimeKind.Local).AddTicks(792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 320, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                schema: "Identity",
                table: "ROLES",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 936, DateTimeKind.Local).AddTicks(5903),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 358, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 858, DateTimeKind.Local).AddTicks(1800),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 303, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 930, DateTimeKind.Local).AddTicks(5185),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 347, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OUTBOX_MESSAGES",
                nullable: false,
                defaultValue: new Guid("04d21804-b82f-4c64-bdff-2ce802f8950e"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("b6db6f6c-4199-43fd-a888-b9e0cc7e923b"));

            migrationBuilder.CreateIndex(
                name: "IX_ROLES_EntityId",
                schema: "Identity",
                table: "ROLES",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ROLES_ENTITIES_EntityId",
                schema: "Identity",
                table: "ROLES",
                column: "EntityId",
                principalSchema: "Identity",
                principalTable: "ENTITIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ROLES_ENTITIES_EntityId",
                schema: "Identity",
                table: "ROLES");

            migrationBuilder.DropIndex(
                name: "IX_ROLES_EntityId",
                schema: "Identity",
                table: "ROLES");

            migrationBuilder.DropColumn(
                name: "EntityId",
                schema: "Identity",
                table: "ROLES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 243, DateTimeKind.Local).AddTicks(935),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 723, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 320, DateTimeKind.Local).AddTicks(8444),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 892, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 358, DateTimeKind.Local).AddTicks(4280),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 936, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 303, DateTimeKind.Local).AddTicks(3701),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 858, DateTimeKind.Local).AddTicks(1800));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 347, DateTimeKind.Local).AddTicks(5528),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 11, 19, 31, 44, 930, DateTimeKind.Local).AddTicks(5185));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OUTBOX_MESSAGES",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("b6db6f6c-4199-43fd-a888-b9e0cc7e923b"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("04d21804-b82f-4c64-bdff-2ce802f8950e"));
        }
    }
}
