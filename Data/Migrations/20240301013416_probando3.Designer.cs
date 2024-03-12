﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teatro.Data;

#nullable disable

namespace Teatro.Data.Migrations
{
    [DbContext(typeof(TeatroContext))]
    [Migration("20240301013416_probando3")]
    partial class probando3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Teatro.Models.Asiento", b =>
                {
                    b.Property<int>("AsientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AsientoId"), 1L, 1);

                    b.Property<bool?>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreAsiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObraId")
                        .HasColumnType("int");

                    b.HasKey("AsientoId");

                    b.HasIndex("ObraId");

                    b.ToTable("Asientos");

                    b.HasData(
                        new
                        {
                            AsientoId = 1,
                            Estado = false,
                            NombreAsiento = "A1"
                        },
                        new
                        {
                            AsientoId = 2,
                            Estado = false,
                            NombreAsiento = "A2"
                        },
                        new
                        {
                            AsientoId = 3,
                            Estado = false,
                            NombreAsiento = "A3"
                        },
                        new
                        {
                            AsientoId = 4,
                            Estado = false,
                            NombreAsiento = "A4"
                        },
                        new
                        {
                            AsientoId = 5,
                            Estado = false,
                            NombreAsiento = "A5"
                        },
                        new
                        {
                            AsientoId = 6,
                            Estado = false,
                            NombreAsiento = "A6"
                        },
                        new
                        {
                            AsientoId = 7,
                            Estado = false,
                            NombreAsiento = "B1"
                        },
                        new
                        {
                            AsientoId = 8,
                            Estado = false,
                            NombreAsiento = "B2"
                        },
                        new
                        {
                            AsientoId = 9,
                            Estado = false,
                            NombreAsiento = "B3"
                        },
                        new
                        {
                            AsientoId = 10,
                            Estado = false,
                            NombreAsiento = "B4"
                        },
                        new
                        {
                            AsientoId = 11,
                            Estado = false,
                            NombreAsiento = "B5"
                        },
                        new
                        {
                            AsientoId = 12,
                            Estado = false,
                            NombreAsiento = "B6"
                        },
                        new
                        {
                            AsientoId = 13,
                            Estado = false,
                            NombreAsiento = "B7"
                        },
                        new
                        {
                            AsientoId = 14,
                            Estado = false,
                            NombreAsiento = "B8"
                        },
                        new
                        {
                            AsientoId = 15,
                            Estado = false,
                            NombreAsiento = "B9"
                        },
                        new
                        {
                            AsientoId = 16,
                            Estado = false,
                            NombreAsiento = "B10"
                        },
                        new
                        {
                            AsientoId = 17,
                            Estado = false,
                            NombreAsiento = "B11"
                        },
                        new
                        {
                            AsientoId = 18,
                            Estado = false,
                            NombreAsiento = "B12"
                        },
                        new
                        {
                            AsientoId = 19,
                            Estado = false,
                            NombreAsiento = "C1"
                        },
                        new
                        {
                            AsientoId = 20,
                            Estado = false,
                            NombreAsiento = "C2"
                        },
                        new
                        {
                            AsientoId = 21,
                            Estado = false,
                            NombreAsiento = "C3"
                        },
                        new
                        {
                            AsientoId = 22,
                            Estado = false,
                            NombreAsiento = "C4"
                        },
                        new
                        {
                            AsientoId = 23,
                            Estado = false,
                            NombreAsiento = "C5"
                        },
                        new
                        {
                            AsientoId = 24,
                            Estado = false,
                            NombreAsiento = "C6"
                        });
                });

            modelBuilder.Entity("Teatro.Models.Obra", b =>
                {
                    b.Property<int>("ObraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObraId"), 1L, 1);

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Imagen")
                        .HasColumnType("varbinary(max)");

                    b.Property<decimal>("PrecioEntrada")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Título")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObraId");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("Teatro.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"), 1L, 1);

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("ObraId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Teatro.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"), 1L, 1);

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Rol")
                        .HasColumnType("bit");

                    b.HasKey("UsuarioId");

                    b.HasIndex("Contraseña")
                        .IsUnique();

                    b.HasIndex("CorreoElectronico")
                        .IsUnique();

                    b.HasIndex("Nombre")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Contraseña = "admin",
                            CorreoElectronico = "admin@admin.com",
                            Nombre = "admin",
                            Rol = true
                        });
                });

            modelBuilder.Entity("Teatro.Models.Asiento", b =>
                {
                    b.HasOne("Teatro.Models.Obra", null)
                        .WithMany("AsientosOcupados")
                        .HasForeignKey("ObraId");
                });

            modelBuilder.Entity("Teatro.Models.Reserva", b =>
                {
                    b.HasOne("Teatro.Models.Obra", "Obra")
                        .WithMany()
                        .HasForeignKey("ObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Teatro.Models.Usuario", null)
                        .WithMany("ListReservas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Obra");
                });

            modelBuilder.Entity("Teatro.Models.Obra", b =>
                {
                    b.Navigation("AsientosOcupados");
                });

            modelBuilder.Entity("Teatro.Models.Usuario", b =>
                {
                    b.Navigation("ListReservas");
                });
#pragma warning restore 612, 618
        }
    }
}