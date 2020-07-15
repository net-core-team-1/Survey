﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey.Identity.Data;

namespace Survey.Identity.Migrations
{
    [DbContext(typeof(SurveyIdentityContext))]
    partial class SurveyIdentityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Survey.Identity.Data.OutBox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("0e5259c7-273b-4599-ac63-85295f01f9e5"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Event")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OUTBOX_MESSAGES");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Entities.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("ENTITIES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MicroServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("MicroServiceId");

                    b.ToTable("FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Invalidated")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("Used")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("REFRESH_TOKENS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("ROLES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLE_CLAIMS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleFeature", b =>
                {
                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssociatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("FeatureId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLES_FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Services.MicroService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("MICRO_SERVICES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastConnexionOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("USERS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("USER_CLAIMS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("USER_LOGINS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AssociatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USERS_ROLES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("USER_TOKENS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Entities.Entity", b =>
                {
                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(new DateTime(2020, 6, 29, 19, 54, 55, 670, DateTimeKind.Local).AddTicks(9134));

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.Entities.NameDesc", "NameDesciption", b1 =>
                        {
                            b1.Property<Guid>("EntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(255)")
                                .HasMaxLength(255);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES");

                            b1.WithOwner()
                                .HasForeignKey("EntityId");
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Features.Feature", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Services.MicroService", "MicroService")
                        .WithMany()
                        .HasForeignKey("MicroServiceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(new DateTime(2020, 6, 29, 19, 54, 55, 637, DateTimeKind.Local).AddTicks(9063));

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES");

                            b1.WithOwner()
                                .HasForeignKey("FeatureId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES");

                            b1.WithOwner()
                                .HasForeignKey("FeatureId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DisableInfo", "DisableInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES");

                            b1.WithOwner()
                                .HasForeignKey("FeatureId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.Features.FeatureInfo", "FeatureInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Action")
                                .IsRequired()
                                .HasColumnName("Action")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("Controller")
                                .IsRequired()
                                .HasColumnName("Controller")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("ControllerActionName")
                                .HasColumnName("ControllerActionName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Description")
                                .HasColumnName("Description")
                                .HasColumnType("nvarchar(500)")
                                .HasMaxLength(500);

                            b1.Property<string>("Label")
                                .HasColumnName("Label")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES");

                            b1.WithOwner()
                                .HasForeignKey("FeatureId");
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Identity.RefreshToken", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.Role", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Entities.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(new DateTime(2020, 6, 29, 19, 54, 55, 644, DateTimeKind.Local).AddTicks(6606));

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DisableInfo", "DisableInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES");

                            b1.WithOwner()
                                .HasForeignKey("RoleId");
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleClaim", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Roles.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleFeature", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Features.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Survey.Identity.Domain.Roles.Role", "Role")
                        .WithMany("RoleFeatures")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Services.MicroService", b =>
                {
                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("MicroServiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(new DateTime(2020, 6, 29, 19, 54, 55, 673, DateTimeKind.Local).AddTicks(3574));

                            b1.HasKey("MicroServiceId");

                            b1.ToTable("MICRO_SERVICES");

                            b1.WithOwner()
                                .HasForeignKey("MicroServiceId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("MicroServiceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("MicroServiceId");

                            b1.ToTable("MICRO_SERVICES");

                            b1.WithOwner()
                                .HasForeignKey("MicroServiceId");
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.User", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Entities.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(new DateTime(2020, 6, 29, 19, 54, 55, 631, DateTimeKind.Local).AddTicks(2657));

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasColumnType("nvarchar(250)")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasColumnType("datetime2")
                                .HasDefaultValue(null);

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Survey.Identity.Domain.Users.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnName("FirstName")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .HasColumnName("LastName")
                                .HasColumnType("nvarchar(50)")
                                .HasMaxLength(50);

                            b1.HasKey("UserId");

                            b1.ToTable("USERS");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserClaim", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserLogin", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserRole", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Survey.Identity.Domain.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserToken", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
