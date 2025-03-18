using Events_PLUS.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Projeto_Events_PLUS.Context
{
    public class Events_Plus_Context : DbContext
    {
        public Events_Plus_Context()
        {
        }

        public Events_Plus_Context(DbContextOptions<Events_Plus_Context> options) : base(options)
        {
        }


        public DbSet<TiposEventos> TipoEvento { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<PresencasEventos> Presenca { get; set; }
        public DbSet<ComentarioEvento> Comentario { get; set; }
        public DbSet<Instituicoes> Instituicao { get; set; }
        public DbSet<TiposUsuarios> TipoUsuarios { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE13-S28\\SQLEXPRESS;Database=EventsPlus;User ID=sa;Password=Senai@134;TrustServerCertificate=true");
            }

        }
    }
}
