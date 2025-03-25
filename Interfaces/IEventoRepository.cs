using Events_PLUS.Domains;

namespace Events_PLUS.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento novoEvento);
        List<Evento> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Evento evento);
        List<Evento> ListarProximosEventos(Guid id);
        List<Evento> ListarPorId(Guid id);
    }
}