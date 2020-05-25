using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingparentIdforentityLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 830, DateTimeKind.Local).AddTicks(1958),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 448, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 891, DateTimeKind.Local).AddTicks(4976),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 497, DateTimeKind.Local).AddTicks(2916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 877, DateTimeKind.Local).AddTicks(6489),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 480, DateTimeKind.Local).AddTicks(5826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 917, DateTimeKind.Local).AddTicks(6308),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 523, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 930, DateTimeKind.Local).AddTicks(4279),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 536, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.CreateIndex(
                name: "IX_ENTITIES_LEVELS_ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ENTITIES_LEVELS_ENTITIES_LEVELS_ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                column: "ParentId",
                principalSchema: "Identity",
                principalTable: "ENTITIES_LEVELS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENTITIES_LEVELS_ENTITIES_LEVELS_ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS");

            migrationBuilder.DropIndex(
                name: "IX_ENTITIES_LEVELS_ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 448, DateTimeKind.Local).AddTicks(9931),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 830, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 497, DateTimeKind.Local).AddTicks(2916),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 891, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 480, DateTimeKind.Local).AddTicks(5826),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 877, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 523, DateTimeKind.Local).AddTicks(9803),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 917, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 11, 48, 33, 536, DateTimeKind.Local).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 930, DateTimeKind.Local).AddTicks(4279));
        }
    }
}
