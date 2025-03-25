using Events_PLUS.Context;
using Events_PLUS.Domains;
using Events_PLUS.Interfaces;
using static Events_PLUS.Repositories.PresencaRepository;

namespace Events_PLUS.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly Events_PLUS_Context _context;
        public PresencaRepository(Events_PLUS_Context context)
        {
            _context = context;
        }

        //---------------------------------------------------------------------------------
        // Atualizar
        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.Presenca.Find(id)!;
                if (presencaBuscado != null)
                {
                    presencaBuscado.Situacao = presenca.Situacao;
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
        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                return presencaBuscada;
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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                if (presencaBuscada != null)
                {
                    _context.Presenca.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Inscrever
        public void Inscrever(Presenca Inscricao)
        {
            try
            {
                _context.Presenca.Add(Inscricao);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Listar
        public List<Presenca> Listar()
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //---------------------------------------------------------------------------------
        // Listar Minhas Presencas
        public List<Presenca> ListarMinhas(Guid id)
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presenca.Where(p => p.UsuarioID == id).ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }

        void IPresencaRepository.Atualizar(Guid id, Presenca presenca)
        {
            throw new NotImplementedException();
        }

        Presenca IPresencaRepository.BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        void IPresencaRepository.Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        void IPresencaRepository.Inscrever(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Presenca> IPresencaRepository.Listar()
        {
            throw new NotImplementedException();
        }

        List<Presenca> IPresencaRepository.ListarMinhasPresencas(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
