using Events_PLUS.Domains;

namespace Events_PLUS.Interfaces
{
    public interface IComentariosEventosRepository
    {
        void Cadastrar(Comentarios comentarioEvento);
        void Deletar(Guid id);
        List<Comentarios> Listar(Guid id);
        Comentarios BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
    }
}
