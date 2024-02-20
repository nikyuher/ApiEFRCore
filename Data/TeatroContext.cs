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

    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaSala> ReservaSalas { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<DetalleSala> DetalleSalas { get; set; }
    public DbSet<Obra> Obras { get; set; }
    public DbSet<Asiento> Asientos { get; set; }
}