﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Survey.Transverse.Infrastracture.Data;

namespace Survey.Transverse.Infrastracture.Migrations
{
    [DbContext(typeof(TransverseContext))]
    partial class TransverseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Survey.Transverse.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Controller")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ControllerActionName")
                        .HasMaxLength(50);

                    b.Property<Guid?>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("13a22305-1767-4167-a680-03dafdf1a260"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 11, 28, 12, 50, 16, 972, DateTimeKind.Local).AddTicks(3040));

                    b.Property<string>("DeleteReason");

                    b.Property<Guid?>("DeletedBy");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<Guid?>("DisabledBy");

                    b.Property<DateTime?>("DisabledOn");

                    b.Property<string>("Label")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Identity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("DeleteReason");

                    b.Property<Guid?>("DeletedBy");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<DateTime>("ExpiryDate");

                    b.Property<bool>("Invalidated");

                    b.Property<string>("JwtId")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Token")
                        .HasMaxLength(250);

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<bool>("Used");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("REFRESH_TOKENS","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Permissions.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new Guid("13a22305-1767-4167-a680-03dafdf1a260"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2019, 11, 28, 12, 50, 16, 982, DateTimeKind.Local).AddTicks(1002));

                    b.Property<string>("DeleteReason");

                    b.Property<Guid?>("DeletedBy");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<Guid?>("DisabledBy");

                    b.Property<DateTime?>("DisabledOn");

                    b.Property<string>("Label")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("PERMISSIONS","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Permissions.PermissionFeature", b =>
                {
                    b.Property<Guid>("FeatureId");

                    b.Property<Guid>("PermissionId");

                    b.Property<DateTime>("AssociatedOn");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("FeatureId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("PERMISSIONS_FEATURES","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DeleteReason")
                        .HasMaxLength(250);

                    b.Property<Guid?>("DeletedBy");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LastConnexionOn");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("USERS","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Users.UserPermission", b =>
                {
                    b.Property<Guid>("PermissionId");

                    b.Property<Guid>("UserId");

                    b.Property<DateTime>("AssociatedOn");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("PermissionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("USER_PERMISSIONS","Identity");
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Identity.RefreshToken", b =>
                {
                    b.HasOne("Survey.Transverse.Domain.Users.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Permissions.PermissionFeature", b =>
                {
                    b.HasOne("Survey.Transverse.Domain.Features.Feature", "Feature")
                        .WithMany("PermissionFeatures")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Survey.Transverse.Domain.Permissions.Permission", "Permission")
                        .WithMany("PermissionFeatures")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Survey.Transverse.Domain.Users.UserPermission", b =>
                {
                    b.HasOne("Survey.Transverse.Domain.Permissions.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Survey.Transverse.Domain.Users.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
