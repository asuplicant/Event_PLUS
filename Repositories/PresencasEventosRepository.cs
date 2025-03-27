using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;

namespace Events_PLUS.Repositories
{
    public class PresencasEventosRepository : IPresencaRepository
    {
        private readonly Events_PLUS_Context _context;

        public PresencasEventosRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------
        // Atualizar
        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.PresencasEventos.Find(id)!;
                if (presencaBuscado != null)
                {
                    presencaBuscado.Situacao = presenca.Situacao;
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Buscar Por Id
        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.PresencasEventos
                   .Select(p => new Presenca
                   {
                       PresencaID = p.PresencaID,
                       Situacao = p.Situacao,

                       Evento = new Evento
                       {
                           EventoID = p.EventoID!,
                           DataEvento = p.Evento!.DataEvento,
                           NomeEvento = p.Evento.NomeEvento,
                           Descricao = p.Evento.Descricao,

                           Instituicao = new Instituicoes
                           {
                               IdInstituicoes = p.Evento.Instituicao!.IdInstituicoes,
                               NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                           }
                       }

                   }).FirstOrDefault(p => p.PresencaID == id)!;
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
                Presenca presencaBuscada = _context.PresencasEventos.Find(id)!;
                if (presencaBuscada != null)
                {
                    _context.PresencasEventos.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Inscrever
        public void Inscrever(Guid id)
        {
            try
            {
                Presenca presencaBuscada = _context.PresencasEventos.Find(id)!;
                if (presencaBuscada != null)
                {
                    _context.PresencasEventos.Remove(presencaBuscada);
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
        public List<Presenca> Listar()
        {
            try
            {
                return _context.PresencasEventos
                     .Select(p => new Presenca
                     {
                         PresencaID = p.PresencaID,
                         Situacao = p.Situacao,

                         Evento = new Evento
                         {
                             EventoID = p.EventoID,
                             DataEvento = p.Evento!.DataEvento,
                             NomeEvento = p.Evento.NomeEvento,
                             Descricao = p.Evento.Descricao,

                             Instituicao = new Instituicoes
                             {
                                 IdInstituicoes = p.Evento.Instituicao!.IdInstituicoes,
                                 NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                             }
                         }

                     }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Listar Minhas Presencas
        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            try
            {
                return _context.PresencasEventos
                .Select(p => new Presenca
                {
                    PresencaID = p.PresencaID,
                    Situacao = p.Situacao,
                    UsuarioID = p.UsuarioID,
                    EventoID = p.EventoID,

                    Evento = new Evento
                    {
                        EventoID = p.EventoID,
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                        Descricao = p.Evento!.Descricao,

                        Instituicao = new Instituicoes
                        {
                            IdInstituicoes = p.Evento!.InstituicaoID,
                        }
                    }
                })
                .Where(p => p.UsuarioID == id)
                .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}