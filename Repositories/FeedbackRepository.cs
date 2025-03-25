using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;

namespace Events_PLUS.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly Events_PLUS_Context _context;

        public FeedbackRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        public Feedback BuscarPorIdUsuario(Guid UsuarioId, Guid EventoId)
        {
            try
            {
                Feedback feedbackBuscado = _context.Feedback.Find(UsuarioId, EventoId)!;
                return feedbackBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Feedback novoFeedback)
        {
            try
            {
                _context.Feedback.Add(novoFeedback);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Feedback feedbackBuscado = _context.Feedback.Find(id)!;
                if (feedbackBuscado != null)
                {
                    _context.Feedback.Remove(feedbackBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Feedback> Listar()
        {
            try
            {
                List<Feedback> listaFeedback = _context.Feedback.ToList();
                return listaFeedback;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
 
        