using Events_PLUS.Domains;

namespace Events_PLUS.Interfaces
{
    public interface ITiposEventosRepository
    {
        void Cadastrar(TiposEventos tipoEventos);
        List<TiposEventos> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, TiposEventos tipoEventos);
        TiposEventos BuscarPorId(Guid id);

    }
}