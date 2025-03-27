using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;

namespace Events_PLUS.Repositories
{
    public class ComentariosEventosRepository : IComentariosEventosRepository
    {
        private readonly Events_PLUS_Context _context;

        public ComentariosEventosRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------
        // Buscar Por Id Usuario
        public Comentarios BuscarPorIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new Comentarios
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuarios
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.UsuarioID == idUsuario && c.EventoID == idEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        public void Cadastrar(Comentarios comentarioEvento)
        {
            try
            {
                comentarioEvento.IdComentarioEvento = Guid.NewGuid();

                _context.ComentariosEventos.Add(comentarioEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Deletar
        public void Deletar(Guid id)
        {
            try
            {
                Comentarios comentarioEventoBuscado = _context.ComentariosEventos.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentariosEventos.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Listar
        public List<Comentarios> Listar(Guid id)
        {
            try
            {
                return _context.ComentariosEventos
                    .Select(c => new Comentarios
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        UsuarioID = c.UsuarioID,
                        EventoID = c.EventoID,

                        Usuario = new Usuarios
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.EventoID == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}