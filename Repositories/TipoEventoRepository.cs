using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Projeto_Events_PLUS.Context;

namespace Events_PLUS.Repositories
{
    public class TipoEventoRepository : ITiposEventosRepository
    {
        private readonly Events_Plus_Context _context;
        public TipoEventoRepository(Events_Plus_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Events_PLUS.Domains.TiposEventos tipoEventos)
        {
            TiposEventos eventoBuscado = _context.TipoEvento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
            }
            _context.SaveChanges();
        }

        //---------------------------------------------------------------------------------
        // TiposEventos BuscarPorId

        public Events_PLUS.Domains.TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                TiposEventos tipoEventoBuscado = _context.TipoEvento.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    return tipoEventoBuscado;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar TiposEventos

        public void Cadastrar(Events_PLUS.Domains.TiposEventos tipoEventos)
        {
            try
            {
                _context.TipoEvento.Add(tipoEventos);

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
                TiposEventos eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.TipoEvento.Remove(eventoBuscado);
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
            List<TiposEventos> ListaEvento = _context.TipoEvento.ToList();
            return ListaEvento;
        }
    }
}

