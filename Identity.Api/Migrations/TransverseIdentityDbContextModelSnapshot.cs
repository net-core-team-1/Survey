﻿// <auto-generated />
using System;
using Identity.Api.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Identity.Api.Migrations
{
    [DbContext(typeof(TransverseIdentityDbContext))]
    partial class TransverseIdentityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Identity.Api.Identity.Domain.Civilities.Civility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(25);

                    b.Property<string>("Name")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Civility","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Features","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.RoleFeatures.AppRoleFeatures", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AssignedBy")
                        .HasColumnName("AssignedBy");

                    b.Property<DateTime>("AssignedOn")
                        .HasColumnName("AssignedOn");

                    b.Property<Guid>("FeatureId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleFeatures","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Roles.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Roles.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int?>("CivilityId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CivilityId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("AppUserId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.Property<Guid?>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserClaims","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.Property<DateTime>("AssociatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2020, 5, 9, 0, 21, 44, 781, DateTimeKind.Utc).AddTicks(5515));

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens","Identity");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Features.Feature", b =>
                {
                    b.OwnsOne("Identity.Api.Identity.Domain.Features.FeatureInfo", "FeatureInfo", b1 =>
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

                            b1.ToTable("Features","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Features.Feature")
                                .WithOne("FeatureInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.Features.FeatureInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
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
                                .HasDefaultValue(new DateTime(2020, 5, 9, 2, 21, 44, 805, DateTimeKind.Local).AddTicks(6851));

                            b1.HasKey("FeatureId");

                            b1.ToTable("Features","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Features.Feature")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.CreateInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletReason")
                                .HasMaxLength(250)
                                .HasDefaultValue(null);

                            b1.Property<bool?>("Deleted")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Deleted")
                                .HasDefaultValue(false);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("Features","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Features.Feature")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.DeleteInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.DisabeleInfo", "DisabeleInfo", b1 =>
                        {
                            b1.Property<Guid>("FeatureId");

                            b1.Property<bool?>("Disabled")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Disabled")
                                .HasDefaultValue(false);

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasDefaultValue(null);

                            b1.HasKey("FeatureId");

                            b1.ToTable("Features","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Features.Feature")
                                .WithOne("DisabeleInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.DisabeleInfo", "FeatureId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.RoleFeatures.AppRoleFeatures", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Features.Feature", "Feature")
                        .WithMany("Roles")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Identity.Api.Identity.Domain.Roles.AppRole", "Role")
                        .WithMany("Features")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Roles.AppRole", b =>
                {
                    b.OwnsOne("Identity.Api.Identity.Domain.CreateInfo", "CreateInfo", b1 =>
                        {
                            b1.Property<Guid>("AppRoleId");

                            b1.Property<Guid?>("CreatedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("CreatedOn")
                                .IsRequired()
                                .ValueGeneratedOnAdd()
                                .HasColumnName("CreatedOn")
                                .HasDefaultValue(new DateTime(2020, 5, 9, 2, 21, 44, 716, DateTimeKind.Local).AddTicks(7403));

                            b1.HasKey("AppRoleId");

                            b1.ToTable("Roles","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Roles.AppRole")
                                .WithOne("CreateInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.CreateInfo", "AppRoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("AppRoleId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeleteReason")
                                .HasMaxLength(50)
                                .HasDefaultValue(null);

                            b1.Property<bool?>("Deleted")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Deleted")
                                .HasDefaultValue(false);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("AppRoleId");

                            b1.ToTable("Roles","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Roles.AppRole")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.DeleteInfo", "AppRoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.DisabeleInfo", "DisableInfo", b1 =>
                        {
                            b1.Property<Guid>("AppRoleId");

                            b1.Property<bool?>("Disabled")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Disabled")
                                .HasDefaultValue(false);

                            b1.Property<Guid?>("DisabledBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DisabledOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DisabledOn")
                                .HasDefaultValue(null);

                            b1.HasKey("AppRoleId");

                            b1.ToTable("Roles","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Roles.AppRole")
                                .WithOne("DisableInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.DisabeleInfo", "AppRoleId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Roles.AppRoleClaim", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Roles.AppRole", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUser", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Civilities.Civility", "Civility")
                        .WithMany()
                        .HasForeignKey("CivilityId");

                    b.OwnsOne("Identity.Api.Identity.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("AppUserId");

                            b1.Property<string>("FirstName")
                                .HasColumnName("FirstName")
                                .HasMaxLength(50);

                            b1.Property<string>("LastName")
                                .HasColumnName("LastName")
                                .HasMaxLength(50);

                            b1.HasKey("AppUserId");

                            b1.ToTable("Users","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Users.AppUser")
                                .WithOne("FullName")
                                .HasForeignKey("Identity.Api.Identity.Domain.FullName", "AppUserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Identity.Api.Identity.Domain.DeleteInfo", "DeleteInfo", b1 =>
                        {
                            b1.Property<Guid>("AppUserId");

                            b1.Property<string>("DeleteReason")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeleteReason")
                                .HasMaxLength(50)
                                .HasDefaultValue(null);

                            b1.Property<bool?>("Deleted")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("Deleted")
                                .HasDefaultValue(false);

                            b1.Property<Guid?>("DeletedBy")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedBy")
                                .HasDefaultValue(null);

                            b1.Property<DateTime?>("DeletedOn")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("DeletedOn")
                                .HasDefaultValue(null);

                            b1.HasKey("AppUserId");

                            b1.ToTable("Users","Identity");

                            b1.HasOne("Identity.Api.Identity.Domain.Users.AppUser")
                                .WithOne("DeleteInfo")
                                .HasForeignKey("Identity.Api.Identity.Domain.DeleteInfo", "AppUserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserClaim", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser")
                        .WithMany("Claims")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserLogin", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserRole", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Roles.AppRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Identity.Api.Identity.Domain.Users.AppUserToken", b =>
                {
                    b.HasOne("Identity.Api.Identity.Domain.Users.AppUser", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
