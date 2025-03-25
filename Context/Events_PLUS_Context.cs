using Events_PLUS.Domains;
using Microsoft.EntityFrameworkCore;

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

        public DbSet<Evento> Evento { get; set; }
        public DbSet<TipoUsuarios> TipoUsuario { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Instituicoes> Instituicao { get; set; }
        public DbSet<TiposEventos> TipoEvento { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NOTE40-S28\\SQLEXPRESS; Database=Event; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            }

        }


    }
}