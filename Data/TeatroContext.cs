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
        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Obra)
            .WithMany()
            .HasForeignKey(r => r.ObraId);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Asiento)
            .WithMany()
            .HasForeignKey(r => r.AsientoId);
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}