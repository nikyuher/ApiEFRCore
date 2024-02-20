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

        //Relaciones entre Reservas y Sala
        modelBuilder.Entity<ReservaSala>()
            .HasKey(obj => new { obj.SalaId, obj.ReservaId });

        modelBuilder.Entity<ReservaSala>()
          .HasOne(obj => obj.Reserva)
          .WithMany(p => p.ListSalas)
          .HasForeignKey(pp => pp.ReservaId);

        modelBuilder.Entity<ReservaSala>()
            .HasOne(pp => pp.Sala)
            .WithMany()
            .HasForeignKey(pp => pp.SalaId);

        //Relaciones entre Sala y Detalle Sala
        modelBuilder.Entity<DetalleSala>()
            .HasKey(obj => new { obj.SalaId, obj.ObraId });

        modelBuilder.Entity<DetalleSala>()
            .HasOne(obj => obj.Sala)
            .WithMany(p => p.Detalles)
            .HasForeignKey(pp => pp.SalaId);

        modelBuilder.Entity<DetalleSala>()
            .HasOne(pp => pp.Obra)
            .WithMany()
            .HasForeignKey(pp => pp.ObraId);

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaSala> ReservaSalas { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<DetalleSala> DetalleSalas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}