using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_PLUS.Domains;

public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuarios tipoUsuario);
    void Deletar(Guid id);
    List<TipoUsuarios> Listar();
    TipoUsuarios BuscarPorId(Guid id);
    void Atualizar(Guid id, TipoUsuarios tipoUsuario);
}