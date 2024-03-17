namespace Teatro.Data;

using Microsoft.EntityFrameworkCore;
using Teatro.Models;

public class TeatroContext : DbContext
{

    public TeatroContext(DbContextOptions<TeatroContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.CorreoElectronico)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Nombre)
            .IsUnique();

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Contraseña)
            .IsUnique();

        //Relacion Reservas a Usuario
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.ListReservas)
            .WithOne()
            .HasForeignKey(r => r.UsuarioId);
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Obra)
            .WithMany()
            .HasForeignKey(r => r.ObraId);

        modelBuilder.Entity<Reserva>()
        .HasOne(r => r.Asiento)
        .WithMany()
        .HasForeignKey(r => r.AsientoId);

        //Creacion Cuenta Administrador
        modelBuilder.Entity<Usuario>().HasData(new Usuario
        {
            UsuarioId = 1,
            Nombre = "admin",
            CorreoElectronico = "admin@admin.com",
            Contraseña = "admin",
            Rol = true
        });

        // Lista de filas y cantidad de asientos 
        var filasAsientos = new List<(string Fila, int CantidadAsientos)>
    {
        ("A", 6),
        ("B", 12),
        ("C", 6)
    };

        int asientoId = 1;

        // Generar asientos para cada fila
        foreach (var filaAsientos in filasAsientos)
        {
            for (int i = 1; i <= filaAsientos.CantidadAsientos; i++)
            {
                modelBuilder.Entity<Asiento>().HasData(new Asiento
                {
                    AsientoId = asientoId,
                    NombreAsiento = $"{filaAsientos.Fila}{i}",
                    Estado = false
                });
                asientoId++;
            }
        }

        modelBuilder.Entity<Obra>().HasData(
                        new Obra
                        {
                            ObraId = 1,
                            Genero = "comedia",
                            Título = "La Extraña Pareja",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 1),
                            PrecioEntrada = 10
                        },
                        new Obra
                        {
                            ObraId = 2,
                            Genero = "comedia",
                            Título = "La Comedia de las Equivocaciones",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 2),
                            PrecioEntrada = 10
                        },
                        new Obra
                        {
                            ObraId = 3,
                            Genero = "comedia",
                            Título = "Un Tranvía llamado Deseo",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 3),
                            PrecioEntrada = 10
                        },
                        new Obra
                        {
                            ObraId = 4,
                            Genero = "terror",
                            Título = "Drácula",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 4),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 5,
                            Genero = "terror",
                            Título = "El Fantasma de Gantersville",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 5),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 6,
                            Genero = "terror",
                            Título = "La Mujer de Negro",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 6),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 7,
                            Genero = "drama",
                            Título = "Edipo Rey",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 7),
                            PrecioEntrada = 20
                        },
                        new Obra
                        {
                            ObraId = 8,
                            Genero = "drama",
                            Título = "La Casa de Bernarda",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 8),
                            PrecioEntrada = 20
                        },
                        new Obra
                        {
                            ObraId = 9,
                            Genero = "drama",
                            Título = "Muerte de un Viajero",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 9),
                            PrecioEntrada = 20
                        },
                        new Obra
                        {
                            ObraId = 10,
                            Genero = "tragedia",
                            Título = "Hamlet",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 10),
                            PrecioEntrada = 25
                        },
                        new Obra
                        {
                            ObraId = 11,
                            Genero = "tragedia",
                            Título = "Macbeth",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 11),
                            PrecioEntrada = 25
                        },
                        new Obra
                        {
                            ObraId = 12,
                            Genero = "tragedia",
                            Título = "Romeo y Julieta",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 12),
                            PrecioEntrada = 25
                        },
                        new Obra
                        {
                            ObraId = 13,
                            Genero = "musical",
                            Título = "El Fantasma de la Ópera",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 13),
                            PrecioEntrada = 30
                        },
                        new Obra
                        {
                            ObraId = 14,
                            Genero = "musical",
                            Título = "El Avaro",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 14),
                            PrecioEntrada = 30
                        },
                        new Obra
                        {
                            ObraId = 15,
                            Genero = "musical",
                            Título = "Frankenstein",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 15),
                            PrecioEntrada = 30
                        },
                        new Obra
                        {
                            ObraId = 16,
                            Genero = "comedia",
                            Título = "El Fantasma de la Opera",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 16),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 17,
                            Genero = "comedia",
                            Título = "El Rey Lear",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 17),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 18,
                            Genero = "comedia",
                            Título = "La Noche de Reyes",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 18),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 19,
                            Genero = "tragedia",
                            Título = "El Inspector",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 19),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 20,
                            Genero = "tragedia",
                            Título = "La Comedia de las Equivocaciones",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 20),
                            PrecioEntrada = 15
                        },
                        new Obra
                        {
                            ObraId = 21,
                            Genero = "tragedia",
                            Título = "La Caída de Bernarda",
                            Descripción = "Una historia llena de giros inesperados y emociones intensas. Explora temas profundos como el amor, la traición y la redención, mientras los personajes enfrentan desafíos que los llevarán al límite de sus capacidades y convicciones.",
                            FechaHora = new DateTime(2022, 1, 21),
                            PrecioEntrada = 15
                        }

         );

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}