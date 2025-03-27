using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using Events_PLUS.Utils;

namespace Events_PLUS.Repositories
{
    public class UsuariosRepository : IUsuarioRepository
    {
        private readonly Events_PLUS_Context _context;

        public UsuariosRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        public Usuarios BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuarios usuarioBuscado = _context.Usuario
                    .Select(u => new Usuarios
                    {
                        IDUsuario = u.IDUsuario,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuarios
                        {
                            IDTipoUsuario = u.IDTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }
                    }).FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado!;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuarios BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuarios novoUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuarios> ListarPorTipo(Guid idTipoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
