using Events_PLUS.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Events_PLUS.Context
{
    public class Events_PLUS_Context : DbContext
    {
        public Events_PLUS_Context()
        {
        }

        public Events_PLUS_Context(DbContextOptions<Events_PLUS_Context> options) : base(options)
        {
        }

        // Ctrl + D = Duplica a linha!
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<Instituicoes> Instituicoes { get; set; }
        public DbSet<PresencasEventos> PresencasEventos { get; set; }
        public DbSet<TiposEventos> TiposEventos { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE13-S28\\SQLEXPRESS;Database=Events_PLUS;User ID=sa;Password=Senai@134;TrustServerCertificate=true");
            }

        }
    }
}
