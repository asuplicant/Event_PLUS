using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.Context;

namespace Events_PLUS.Repositories
{
    public class TipoEventoRepository : ITiposEventosRepository
    {
        // Variável que armazena o context

        // Método Construtivo

        // Desenvolver os métodos que foram criados na minha interface

        private readonly Events_PLUS_Context _context;
        public TipoEventoRepository(Events_PLUS_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Events_PLUS.Domains.TiposEventos tipoEventos)
        {
            TiposEventos eventoBuscado = _context.TiposEventos.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
            }
            _context.SaveChanges();
        }

        //---------------------------------------------------------------------------------
        // TiposEventos BuscarPorId

        public TiposEventos BuscarPorId(Guid id)
        {
            TiposEventos tiposEventosBuscado = _context.TiposEventos.Find(id)!;
            return tiposEventosBuscado;
        }

        //---------------------------------------------------------------------------------
        // Cadastrar TiposEventos

        public void Cadastrar(Events_PLUS.Domains.TiposEventos tipoEventos)
        {
            try
            {
                _context.TiposEventos.Add(tipoEventos);

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
                TiposEventos eventoBuscado = _context.TiposEventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.TiposEventos.Remove(eventoBuscado);
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
        public List<TiposEventos> Listar()
        {
            List<TiposEventos> ListaEvento = _context.TiposEventos.ToList();
            return ListaEvento;
        }
    }
}

