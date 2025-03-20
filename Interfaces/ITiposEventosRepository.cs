using Events_PLUS.Domains;

namespace Events_PLUS.Interfaces
{
        public interface ITiposEventosRepository
        {
            
            // Cadastrar
            void Cadastrar(TiposEventos tipoEvento);

            // Listar
            List<TiposEventos> Listar();

            // Deletar
            void Deletar(Guid id);

            // Atualizar
            void Atualizar(Guid id, TiposEventos tipoEvento);
            
            // BuscarPorId
            TiposEventos BuscarPorId(Guid id);
        }
    }
