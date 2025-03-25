using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;

namespace Events_PLUS.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Events_PLUS_Context _context;
        public EventoRepository(Events_PLUS_Context context)
        {
            _context = context;
        }


        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                    eventoBuscado.DataEvento = evento.DataEvento;
                    eventoBuscado.Descricao = evento.Descricao;
                    eventoBuscado.TipoEventoID = evento.TipoEventoID;
                }
                _context.Evento.Update(eventoBuscado!);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            {
                try
                {
                    if (novoEvento.DataEvento < DateTime.Now)
                    {
                        throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                    }
                    novoEvento.EventoID = Guid.NewGuid();
                    _context.Evento.Add(novoEvento);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _context.Evento.Find(id)!;
                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Evento> Listar()
        {
            try
            {
                List<Evento> listaEventos = _context.Evento.ToList();

                return listaEventos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                List<Evento> listaEvento = _context.Evento.Where(p => p.EventoID == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Evento> listarProximoEvento = _context.Evento.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
                return listarProximoEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}