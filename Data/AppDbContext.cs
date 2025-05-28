using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Psicologo> Psicologos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Sessao> Sessoes { get; set; }
}