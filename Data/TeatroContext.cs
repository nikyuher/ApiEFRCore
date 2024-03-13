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
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}