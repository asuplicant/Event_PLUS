using System.Xml.Linq;
using Events_PLUS.Context;
using Events_PLUS.Domains;


namespace Events_PLUS.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Events_PLUS_Context _context;
        public TipoUsuarioRepository(Events_PLUS_Context context)

        {
            _context = context;
        }

        //---------------------------------------------------------------------------------
        // Atualizar
        public void Atualizar(Guid id, TipoUsuarios tipoUsuario)
        {
            try
            {
                TipoUsuarios tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {

                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
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

        public TipoUsuarios BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuarios tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Cadastrar

        public void Cadastrar(TipoUsuarios tipoUsuario)
        {
            try
            {
                _context.TipoUsuario.Add(tipoUsuario);
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
                TipoUsuarios tipoUsuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(tipoUsuarioBuscado);
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

        public List<TipoUsuarios> Listar()
        {
            return _context.TipoUsuario.ToList();
        }
    }
}