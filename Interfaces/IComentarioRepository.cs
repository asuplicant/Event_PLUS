﻿namespace Events_PLUS.Interfaces
{
        public interface IComentarioRepository
        {
            void Cadastrar(IComentarioRepository comentario);

            void Deletar(Guid id);

            List<IComentarioRepository> Listar(Guid id);

            IComentarioRepository BuscarPorIdUsuario(Guid idUsuario, Guid idEvento);
        }
    }

