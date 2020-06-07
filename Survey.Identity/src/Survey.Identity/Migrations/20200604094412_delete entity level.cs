using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Identity.Migrations
{
    public partial class deleteentitylevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ENTITIES_ENTITIES_LEVELS_EntityLevelId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.DropForeignKey(
                name: "FK_ENTITIES_ENTITIES_ParentId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.DropTable(
                name: "ENTITIES_LEVELS",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_ENTITIES_EntityLevelId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.DropIndex(
                name: "IX_ENTITIES_ParentId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutboxMessages",
                table: "OutboxMessages");

            migrationBuilder.DropColumn(
                name: "EntityLevelId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "Identity",
                table: "ENTITIES");

            migrationBuilder.RenameTable(
                name: "OutboxMessages",
                newName: "OUTBOX_MESSAGES");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 243, DateTimeKind.Local).AddTicks(935),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 299, DateTimeKind.Local).AddTicks(8317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 320, DateTimeKind.Local).AddTicks(8444),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 342, DateTimeKind.Local).AddTicks(9286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 358, DateTimeKind.Local).AddTicks(4280),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 390, DateTimeKind.Local).AddTicks(232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 303, DateTimeKind.Local).AddTicks(3701),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 328, DateTimeKind.Local).AddTicks(6346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true,
                defaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 347, DateTimeKind.Local).AddTicks(5528),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 381, DateTimeKind.Local).AddTicks(7939));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OUTBOX_MESSAGES",
                nullable: false,
                defaultValue: new Guid("b6db6f6c-4199-43fd-a888-b9e0cc7e923b"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("1a72cd9b-d2f3-4bd4-a91f-bd4c26efc855"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OUTBOX_MESSAGES",
                table: "OUTBOX_MESSAGES",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OUTBOX_MESSAGES",
                table: "OUTBOX_MESSAGES");

            migrationBuilder.RenameTable(
                name: "OUTBOX_MESSAGES",
                newName: "OutboxMessages");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "USERS",
                nullable: true,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 299, DateTimeKind.Local).AddTicks(8317),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 243, DateTimeKind.Local).AddTicks(935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ROLES",
                nullable: true,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 342, DateTimeKind.Local).AddTicks(9286),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 320, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "MICRO_SERVICES",
                nullable: true,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 390, DateTimeKind.Local).AddTicks(232),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 358, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: true,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 328, DateTimeKind.Local).AddTicks(6346),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 303, DateTimeKind.Local).AddTicks(3701));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true,
                defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 381, DateTimeKind.Local).AddTicks(7939),
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValue: new DateTime(2020, 6, 4, 9, 44, 11, 347, DateTimeKind.Local).AddTicks(5528));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityLevelId",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "Identity",
                table: "ENTITIES",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OutboxMessages",
                nullable: false,
                defaultValue: new Guid("1a72cd9b-d2f3-4bd4-a91f-bd4c26efc855"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("b6db6f6c-4199-43fd-a888-b9e0cc7e923b"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutboxMessages",
                table: "OutboxMessages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ENTITIES_LEVELS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 5, 26, 9, 28, 35, 369, DateTimeKind.Local).AddTicks(3564)),
                    DeletReason = table.Column<string>(maxLength: 250, nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTITIES_LEVELS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENTITIES_LEVELS_ENTITIES_LEVELS_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Identity",
                        principalTable: "ENTITIES_LEVELS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENTITIES_EntityLevelId",
                schema: "Identity",
                table: "ENTITIES",
                column: "EntityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ENTITIES_ParentId",
                schema: "Identity",
                table: "ENTITIES",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ENTITIES_LEVELS_ParentId",
                schema: "Identity",
                table: "ENTITIES_LEVELS",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ENTITIES_ENTITIES_LEVELS_EntityLevelId",
                schema: "Identity",
                table: "ENTITIES",
                column: "EntityLevelId",
                principalSchema: "Identity",
                principalTable: "ENTITIES_LEVELS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ENTITIES_ENTITIES_ParentId",
                schema: "Identity",
                table: "ENTITIES",
                column: "ParentId",
                principalSchema: "Identity",
                principalTable: "ENTITIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
