﻿// <auto-generated />
using System;
using E_Tailor.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Tailor.Migrations
{
    [DbContext(typeof(E_TailorContext))]
    [Migration("20211201014808_EnitiesUpdated2")]
    partial class EnitiesUpdated2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Appointment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Costumerid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Costumerid");

                    b.ToTable("Apointments");
                });

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Cloth", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Costumerid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Costumerid");

                    b.ToTable("Clothes");
                });

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Registry", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Tailorid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Tailorid");

                    b.ToTable("Registries");
                });

            modelBuilder.Entity("E_Tailor.Entity.Auth.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("E_Tailor.Entity.Auth.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idRol");

                    b.ToTable("User");
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Costumer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idUser");

                    b.ToTable("Costumers");
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Manager", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idUser");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Tailor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idUser");

                    b.ToTable("Tailors");
                });

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Appointment", b =>
                {
                    b.HasOne("E_Tailor.Entity.Users.Costumer", null)
                        .WithMany("appointments")
                        .HasForeignKey("Costumerid");
                });

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Cloth", b =>
                {
                    b.HasOne("E_Tailor.Entity.Users.Costumer", null)
                        .WithMany("clothes")
                        .HasForeignKey("Costumerid");
                });

            modelBuilder.Entity("E_Tailor.Entity.Appointments.Registry", b =>
                {
                    b.HasOne("E_Tailor.Entity.Users.Tailor", null)
                        .WithMany("registries")
                        .HasForeignKey("Tailorid");
                });

            modelBuilder.Entity("E_Tailor.Entity.Auth.User", b =>
                {
                    b.HasOne("E_Tailor.Entity.Auth.Rol", "rol")
                        .WithMany()
                        .HasForeignKey("idRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Costumer", b =>
                {
                    b.HasOne("E_Tailor.Entity.Auth.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Manager", b =>
                {
                    b.HasOne("E_Tailor.Entity.Auth.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Tailor.Entity.Users.Tailor", b =>
                {
                    b.HasOne("E_Tailor.Entity.Auth.User", "user")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
