using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class initproj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "FEATURES",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Controller = table.Column<string>(maxLength: 50, nullable: false),
                    ControllerActionName = table.Column<string>(nullable: true),
                    Action = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 305, DateTimeKind.Local).AddTicks(6432)),
                    CreatedBy = table.Column<Guid>(nullable: false, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    DisabledOn = table.Column<DateTime>(nullable: true),
                    DisabledBy = table.Column<Guid>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletReason = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEATURES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 321, DateTimeKind.Local).AddTicks(8171)),
                    CreatedBy = table.Column<Guid>(nullable: false, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    Label = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    DisabledOn = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 327, DateTimeKind.Local).AddTicks(1415)),
                    DisabledBy = table.Column<Guid>(nullable: false, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletReason = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeletReason = table.Column<string>(maxLength: 250, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 4, 5, 11, 36, 27, 273, DateTimeKind.Local).AddTicks(4960)),
                    CreatedBy = table.Column<Guid>(nullable: false, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    LastConnexionOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS_FEATURES",
                schema: "Identity",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(nullable: false),
                    FeatureId = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AssociatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS_FEATURES", x => new { x.FeatureId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PERMISSIONS_FEATURES_FEATURES_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "Identity",
                        principalTable: "FEATURES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISSIONS_FEATURES_PERMISSIONS_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Identity",
                        principalTable: "PERMISSIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "REFRESH_TOKENS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Token = table.Column<string>(maxLength: 250, nullable: true),
                    JwtId = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Invalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFRESH_TOKENS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REFRESH_TOKENS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_PERMISSIONS",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    AssociatedOn = table.Column<DateTime>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PERMISSIONS", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_PERMISSIONS_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PERMISSIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSIONS_FEATURES_PermissionId",
                schema: "Identity",
                table: "PERMISSIONS_FEATURES",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_REFRESH_TOKENS_UserId",
                schema: "Identity",
                table: "REFRESH_TOKENS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PERMISSIONS_UserId",
                schema: "Identity",
                table: "USER_PERMISSIONS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERMISSIONS_FEATURES",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "REFRESH_TOKENS",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "USER_PERMISSIONS",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FEATURES",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PERMISSIONS",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "Identity");
        }
    }
}
