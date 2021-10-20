﻿// <auto-generated />
using System;
using DiscoverAirline.Security.Rule.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiscoverAirline.Security.Rule.Migrations
{
    [DbContext(typeof(SecurityContext))]
    [Migration("20211015143409_addColumnAllTables_ColumnUpdateDateAndColumnActive_202110153311")]
    partial class addColumnAllTables_ColumnUpdateDateAndColumnActive_202110153311
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Controller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Controllers");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ControllerActions", b =>
                {
                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<int>("ControllerId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ActionId", "ControllerId");

                    b.HasIndex("ControllerId");

                    b.ToTable("ControllerActions");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ProfileRoles", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProfileId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("ProfileRoles");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BusinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.RoleServices", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("RoleServices");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ServiceControllers", b =>
                {
                    b.Property<int>("ControllerId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ControllerId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceControllers");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(96)
                        .HasColumnType("nvarchar(96)")
                        .HasColumnName("Email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Password");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.UserRefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime")
                        .HasColumnName("ExpirationDate");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)")
                        .HasColumnName("Code");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Tokens");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ControllerActions", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Action", "Action")
                        .WithMany("Controllers")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Controller", "Controller")
                        .WithMany("Actions")
                        .HasForeignKey("ControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Controller");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Profile", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("DiscoverAirline.Security.Domain.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ProfileRoles", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Profile", "Profile")
                        .WithMany("Roles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Role", "Role")
                        .WithMany("Profiles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.RoleServices", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Role", "Role")
                        .WithMany("Services")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Service", "Service")
                        .WithMany("Roles")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.ServiceControllers", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Controller", "Controller")
                        .WithMany("Services")
                        .HasForeignKey("ControllerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiscoverAirline.Security.Domain.Entities.Service", "Service")
                        .WithMany("Controllers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Controller");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.UserRefreshToken", b =>
                {
                    b.HasOne("DiscoverAirline.Security.Domain.Entities.User", "User")
                        .WithOne("Token")
                        .HasForeignKey("DiscoverAirline.Security.Domain.Entities.UserRefreshToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Action", b =>
                {
                    b.Navigation("Controllers");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Controller", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Profile", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Role", b =>
                {
                    b.Navigation("Profiles");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.Service", b =>
                {
                    b.Navigation("Controllers");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("DiscoverAirline.Security.Domain.Entities.User", b =>
                {
                    b.Navigation("Profile");

                    b.Navigation("Token");
                });
#pragma warning restore 612, 618
        }
    }
}
