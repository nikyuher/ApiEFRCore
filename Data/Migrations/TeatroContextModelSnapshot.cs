﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teatro.Data;

#nullable disable

namespace Teatro.Data.Migrations
{
    [DbContext(typeof(TeatroContext))]
    partial class TeatroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

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

                    b.HasData(
                        new
                        {
                            ObraId = 1,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 10m,
                            Título = "La Extraña Pareja"
                        },
                        new
                        {
                            ObraId = 2,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 10m,
                            Título = "La Comedia de las Equivocaciones"
                        },
                        new
                        {
                            ObraId = 3,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 10m,
                            Título = "Un Tranvía llamado Deseo"
                        },
                        new
                        {
                            ObraId = 4,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "terror",
                            PrecioEntrada = 15m,
                            Título = "Drácula"
                        },
                        new
                        {
                            ObraId = 5,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "terror",
                            PrecioEntrada = 15m,
                            Título = "El Fantasma de Gantersville"
                        },
                        new
                        {
                            ObraId = 6,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "terror",
                            PrecioEntrada = 15m,
                            Título = "La Mujer de Negro"
                        },
                        new
                        {
                            ObraId = 7,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "drama",
                            PrecioEntrada = 20m,
                            Título = "Edipo Rey"
                        },
                        new
                        {
                            ObraId = 8,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "drama",
                            PrecioEntrada = 20m,
                            Título = "La Casa de Bernarda"
                        },
                        new
                        {
                            ObraId = 9,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "drama",
                            PrecioEntrada = 20m,
                            Título = "Muerte de un Viajero"
                        },
                        new
                        {
                            ObraId = 10,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 25m,
                            Título = "Hamlet"
                        },
                        new
                        {
                            ObraId = 11,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 25m,
                            Título = "Macbeth"
                        },
                        new
                        {
                            ObraId = 12,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 25m,
                            Título = "Romeo y Julieta"
                        },
                        new
                        {
                            ObraId = 13,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "musical",
                            PrecioEntrada = 30m,
                            Título = "El Fantasma de la Ópera"
                        },
                        new
                        {
                            ObraId = 14,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "musical",
                            PrecioEntrada = 30m,
                            Título = "El Avaro"
                        },
                        new
                        {
                            ObraId = 15,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "musical",
                            PrecioEntrada = 30m,
                            Título = "Frankenstein"
                        },
                        new
                        {
                            ObraId = 16,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 15m,
                            Título = "El Fantasma de la Opera"
                        },
                        new
                        {
                            ObraId = 17,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 15m,
                            Título = "El Rey Lear"
                        },
                        new
                        {
                            ObraId = 18,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "comedia",
                            PrecioEntrada = 15m,
                            Título = "La Noche de Reyes"
                        },
                        new
                        {
                            ObraId = 19,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 15m,
                            Título = "El Inspector"
                        },
                        new
                        {
                            ObraId = 20,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 15m,
                            Título = "La Comedia de las Equivocaciones"
                        },
                        new
                        {
                            ObraId = 21,
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Genero = "tragedia",
                            PrecioEntrada = 15m,
                            Título = "La Caída de Bernarda"
                        });
                });

            modelBuilder.Entity("Teatro.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"), 1L, 1);

                    b.Property<int>("AsientoId")
                        .HasColumnType("int");

                    b.Property<int>("ObraId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("AsientoId");

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
                    b.HasOne("Teatro.Models.Asiento", "Asiento")
                        .WithMany()
                        .HasForeignKey("AsientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Asiento");

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
