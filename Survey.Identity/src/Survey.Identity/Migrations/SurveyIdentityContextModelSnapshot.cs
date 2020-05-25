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
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Survey.Identity.Domain.Entities.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("EntityLevelId");

                    b.Property<Guid?>("ParentId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("EntityLevelId");

                    b.HasIndex("ParentId");

                    b.ToTable("ENTITIES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Entities.EntityLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ParentId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ENTITIES_LEVELS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("MicroServiceId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("MicroServiceId");

                    b.ToTable("FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<bool>("Invalidated");

                    b.Property<string>("JwtId")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Token")
                        .HasMaxLength(250);

                    b.Property<bool>("Used");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("REFRESH_TOKENS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLE_CLAIMS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleFeature", b =>
                {
                    b.Property<Guid>("FeatureId");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime>("AssociatedOn");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("FeatureId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLES_FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Services.MicroService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("MICRO_SERVICES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<Guid?>("EntityId");

                    b.Property<DateTime?>("LastConnexionOn");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
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
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("USER_CLAIMS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("USER_LOGINS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime>("AssociatedOn");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("USERS_ROLES","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("USER_TOKENS","Identity");
                });

            modelBuilder.Entity("Survey.Identity.Domain.Entities.Entity", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Entities.EntityLevel", "EntityLevel")
                        .WithMany()
                        .HasForeignKey("EntityLevelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Survey.Identity.Domain.Entities.Entity", "ParentEntity")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Survey.Identity.Domain.Entities.FunctionalCode", "FuncCode", b1 =>
                        {
                            b1.Property<Guid>("EntityId");

                            b1.Property<string>("Code")
                                .IsRequired()
                                .HasColumnName("Code")
                                .HasMaxLength(6);

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.Entity")
                                .WithOne("FuncCode")
                                .HasForeignKey("Survey.Identity.Domain.Entities.FunctionalCode", "EntityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 30, 997, DateTimeKind.Local).AddTicks(5573));

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.Entity")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "EntityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.Entity")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "EntityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.Entities.NameDesc", "NameDesciption", b1 =>
                        {
                            b1.Property<Guid>("EntityId");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnName("Description")
                                .HasMaxLength(255);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasMaxLength(50);

                            b1.HasKey("EntityId");

                            b1.ToTable("ENTITIES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.Entity")
                                .WithOne("NameDesciption")
                                .HasForeignKey("Survey.Identity.Domain.Entities.NameDesc", "EntityId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Entities.EntityLevel", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Entities.EntityLevel", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityLevelId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 30, 984, DateTimeKind.Local).AddTicks(58));

                            b1.HasKey("EntityLevelId");

                            b1.ToTable("ENTITIES_LEVELS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.EntityLevel")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "EntityLevelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("EntityLevelId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("EntityLevelId");

                            b1.ToTable("ENTITIES_LEVELS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.EntityLevel")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "EntityLevelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.Entities.NameDesc", "NameDesciption", b1 =>
                        {
                            b1.Property<Guid>("EntityLevelId");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnName("Description")
                                .HasMaxLength(255);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnName("Name")
                                .HasMaxLength(50);

                            b1.HasKey("EntityLevelId");

                            b1.ToTable("ENTITIES_LEVELS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Entities.EntityLevel")
                                .WithOne("NameDesciption")
                                .HasForeignKey("Survey.Identity.Domain.Entities.NameDesc", "EntityLevelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Features.Feature", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Services.MicroService", "MicroService")
                        .WithMany()
                        .HasForeignKey("MicroServiceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.OwnsOne("Survey.Identity.Domain.Features.FeatureInfo", "FeatureInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<string>("Action")
                                .IsRequired()
                                .HasColumnName("Action")
                                .HasMaxLength(50);

                            b1.Property<string>("Controller")
                                .IsRequired()
                                .HasColumnName("Controller")
                                .HasMaxLength(50);

                            b1.Property<string>("ControllerActionName")
                                .HasColumnName("ControllerActionName");

                            b1.Property<string>("Description")
                                .HasColumnName("Description")
                                .HasMaxLength(500);

                            b1.Property<string>("Label")
                                .HasColumnName("Label")
                                .HasMaxLength(50);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Features.Feature")
                                .WithOne("FeatureInfo")
                                .HasForeignKey("Survey.Identity.Domain.Features.FeatureInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 30, 942, DateTimeKind.Local).AddTicks(5728));

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Features.Feature")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Features.Feature")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DisableInfo", "DisableInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("FEATURES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Features.Feature")
                                .WithOne("DisableInfo")
                                .HasForeignKey("Survey.Identity.Domain.DisableInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Identity.RefreshToken", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.Role", b =>
                {
                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 30, 956, DateTimeKind.Local).AddTicks(8056));

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Roles.Role")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "RoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Roles.Role")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "RoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DisableInfo", "DisableInfo", b1 =>
                        {
                            b1.Property<Guid>("RoleId");

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasDefaultValue(null);

                            b1.HasKey("RoleId");

                            b1.ToTable("ROLES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Roles.Role")
                                .WithOne("DisableInfo")
                                .HasForeignKey("Survey.Identity.Domain.DisableInfo", "RoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleClaim", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Roles.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Roles.RoleFeature", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Features.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Survey.Identity.Domain.Roles.Role", "Role")
                        .WithMany("RoleFeatures")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Services.MicroService", b =>
                {
                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("MicroServiceId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 31, 5, DateTimeKind.Local).AddTicks(9082));

                            b1.HasKey("MicroServiceId");

                            b1.ToTable("MICRO_SERVICES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Services.MicroService")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "MicroServiceId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("MicroServiceId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("MicroServiceId");

                            b1.ToTable("MICRO_SERVICES","Identity");

                            b1.HasOne("Survey.Identity.Domain.Services.MicroService")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "MicroServiceId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.User", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Entities.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");

                    b.OwnsOne("Survey.Identity.Domain.Users.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("FirstName")
                                .HasColumnName("FirstName")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .HasColumnName("LastName")
                                .HasMaxLength(50);

                            b1.HasKey("UserId");

                            b1.ToTable("USERS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Users.User")
                                .WithOne("FullName")
                                .HasForeignKey("Survey.Identity.Domain.Users.FullName", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 24, 16, 23, 30, 914, DateTimeKind.Local).AddTicks(6291));

                            b1.HasKey("UserId");

                            b1.ToTable("USERS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Users.User")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Survey.Identity.Domain.CreateInfo", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Survey.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("UserId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("UserId");

                            b1.ToTable("USERS","Identity");

                            b1.HasOne("Survey.Identity.Domain.Users.User")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Survey.Identity.Domain.DeleteInfo", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserClaim", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserLogin", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserRole", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Survey.Identity.Domain.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Survey.Identity.Domain.Users.UserToken", b =>
                {
                    b.HasOne("Survey.Identity.Domain.Users.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
