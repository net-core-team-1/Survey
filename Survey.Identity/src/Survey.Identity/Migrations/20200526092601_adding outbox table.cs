using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingoutboxtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 488, DateTimeKind.Local).AddTicks(4934),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 914, DateTimeKind.Local).AddTicks(6291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 531, DateTimeKind.Local).AddTicks(9329),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 956, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 580, DateTimeKind.Local).AddTicks(3507),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 31, 5, DateTimeKind.Local).AddTicks(9082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 517, DateTimeKind.Local).AddTicks(2861),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 942, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 559, DateTimeKind.Local).AddTicks(2442),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 984, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 572, DateTimeKind.Local).AddTicks(2385),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 997, DateTimeKind.Local).AddTicks(5573));

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

            migrationBuilder.CreateTable(
                name: "OutboxMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true),
                    ProcessedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboxMessages_BaseEvent_EventId",
                        column: x => x.EventId,
                        principalTable: "BaseEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessages_EventId",
                table: "OutboxMessages",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboxMessages");

            migrationBuilder.DropTable(
                name: "BaseEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 914, DateTimeKind.Local).AddTicks(6291),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 488, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 956, DateTimeKind.Local).AddTicks(8056),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 531, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 31, 5, DateTimeKind.Local).AddTicks(9082),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 580, DateTimeKind.Local).AddTicks(3507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 942, DateTimeKind.Local).AddTicks(5728),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 517, DateTimeKind.Local).AddTicks(2861));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 984, DateTimeKind.Local).AddTicks(58),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 559, DateTimeKind.Local).AddTicks(2442));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 24, 16, 23, 30, 997, DateTimeKind.Local).AddTicks(5573),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 26, 0, 572, DateTimeKind.Local).AddTicks(2385));
        }
    }
}
