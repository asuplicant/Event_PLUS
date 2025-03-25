using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.DTO;
using Events_PLUS.Utils;

namespace Events_PLUS.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Events_PLUS_Context _context;

        public UsuarioRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senhas!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuarios BuscarPorID(Guid id)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuarios.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            try
            {
                novoUsuario.Senhas = Criptografia.GerarHash(novoUsuario.Senhas!);

                _context.Usuarios.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        Usuarios IUsuarioRepository.BuscarPorEmailESenha(string Email, string Senha)
        {
            throw new NotImplementedException();
        }

        Usuarios IUsuarioRepository.BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        void IUsuarioRepository.Cadastrar(Usuarios novoUsuario)
        {
            throw new NotImplementedException();
        }

        List<Usuarios> IUsuarioRepository.ListarPorTipo(Guid idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}

        