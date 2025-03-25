using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.Context;

namespace Events_PLUS.Repositories
{
    public class TipoEventoRepository : ITiposEventosRepository
    {
        private readonly Events_PLUS_Context _context;
        public TipoEventoRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------
        // Atualizar
        public void Atualizar(Guid id, TiposEventos tiposEventos)
        {
            try
            {
                TiposEventos tiposEventosBuscado = _context.TipoEvento.Find(id)!;

                if (tiposEventosBuscado != null)
                {
                    tiposEventosBuscado.TituloTipoEvento = tiposEventos.TituloTipoEvento;
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
        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                TiposEventos tiposEventosBuscado = _context.TipoEvento.Find(id)!;
                return tiposEventosBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar
        public void Cadastrar(TiposEventos tiposEventos)
        {
            try
            {
                _context.TipoEvento.Add(tiposEventos);
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
                TiposEventos tiposEventos = _context.TipoEvento.Find(id)!;

                if (tiposEventos != null)
                {
                    _context.TipoEvento.Remove(tiposEventos);
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
            return _context.TipoEvento.ToList();
        }
    }
}

