using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingoutboxtablewithitsmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutboxMessages_BaseEvent_EventId",
                table: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "BaseEvent");

            migrationBuilder.DropIndex(
                name: "IX_OutboxMessages_EventId",
                table: "OutboxMessages");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 299, DateTimeKind.Local).AddTicks(8317),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 488, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 342, DateTimeKind.Local).AddTicks(9286),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 531, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 390, DateTimeKind.Local).AddTicks(232),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 580, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 328, DateTimeKind.Local).AddTicks(6346),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 517, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 369, DateTimeKind.Local).AddTicks(3564),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 559, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 381, DateTimeKind.Local).AddTicks(7939),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 572, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessedAt",
                table: "OutboxMessages",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OutboxMessages",
                nullable: false,
                defaultValue: new Guid("1a72cd9b-d2f3-4bd4-a91f-bd4c26efc855"),
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "OutboxMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Event",
                table: "OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 488, DateTimeKind.Local).AddTicks(4934),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 299, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 531, DateTimeKind.Local).AddTicks(9329),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 342, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 580, DateTimeKind.Local).AddTicks(3507),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 390, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 517, DateTimeKind.Local).AddTicks(2861),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 328, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 559, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 369, DateTimeKind.Local).AddTicks(3564));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 572, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 381, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessedAt",
                table: "OutboxMessages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OutboxMessages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("1a72cd9b-d2f3-4bd4-a91f-bd4c26efc855"));

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "OutboxMessages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OccuredOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEvent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessages_EventId",
                table: "OutboxMessages",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutboxMessages_BaseEvent_EventId",
                table: "OutboxMessages",
                column: "EventId",
                principalTable: "BaseEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
