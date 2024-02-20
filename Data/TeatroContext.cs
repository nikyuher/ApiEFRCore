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

        //Relaciones entre Reservas y DetalleReserva
        modelBuilder.Entity<DetalleReserva>()
            .HasKey(obj => new { obj.ReservaId, obj.ObraId });

        modelBuilder.Entity<DetalleReserva>()
          .HasOne(obj => obj.Reserva)
          .WithMany(p => p.Detalles)
          .HasForeignKey(pp => pp.ReservaId);

        modelBuilder.Entity<DetalleReserva>()
            .HasOne(pp => pp.Obra)
            .WithMany()
            .HasForeignKey(pp => pp.ObraId);


    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<DetalleReserva> DetalleReservas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}