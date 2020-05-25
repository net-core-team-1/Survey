using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class addingmicroservices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 47, DateTimeKind.Local).AddTicks(3158),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 830, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 89, DateTimeKind.Local).AddTicks(6375),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 891, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 75, DateTimeKind.Local).AddTicks(7168),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 877, DateTimeKind.Local).AddTicks(6489));

            migrationBuilder.AddColumn<Guid>(
                name: "MicroServiceId",
                schema: "Identity",
                table: "FEATURES",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 115, DateTimeKind.Local).AddTicks(4328),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 917, DateTimeKind.Local).AddTicks(6308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 128, DateTimeKind.Local).AddTicks(328),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 930, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.CreateTable(
                name: "MICRO_SERVICES",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 136, DateTimeKind.Local).AddTicks(2981)),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletReason = table.Column<string>(maxLength: 250, nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MICRO_SERVICES", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEATURES_MicroServiceId",
                schema: "Identity",
                table: "FEATURES",
                column: "MicroServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FEATURES_MICRO_SERVICES_MicroServiceId",
                schema: "Identity",
                table: "FEATURES",
                column: "MicroServiceId",
                principalSchema: "Identity",
                principalTable: "MICRO_SERVICES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FEATURES_MICRO_SERVICES_MicroServiceId",
                schema: "Identity",
                table: "FEATURES");

            migrationBuilder.DropTable(
                name: "MICRO_SERVICES",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_FEATURES_MicroServiceId",
                schema: "Identity",
                table: "FEATURES");

            migrationBuilder.DropColumn(
                name: "MicroServiceId",
                schema: "Identity",
                table: "FEATURES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 830, DateTimeKind.Local).AddTicks(1958),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 47, DateTimeKind.Local).AddTicks(3158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 891, DateTimeKind.Local).AddTicks(4976),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 89, DateTimeKind.Local).AddTicks(6375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 877, DateTimeKind.Local).AddTicks(6489),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 75, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 917, DateTimeKind.Local).AddTicks(6308),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 115, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 20, 21, 21, 51, 930, DateTimeKind.Local).AddTicks(4279),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 23, 9, 34, 31, 128, DateTimeKind.Local).AddTicks(328));
        }
    }
}
