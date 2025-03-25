using Events_PLUS.Domains;

namespace Events_PLUS.Interfaces
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback novoFeedback);
        void Deletar(Guid id);
        List<Feedback> Listar();

        Feedback BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId);
    }
}