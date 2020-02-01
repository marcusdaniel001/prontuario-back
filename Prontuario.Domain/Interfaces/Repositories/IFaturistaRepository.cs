using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface IFaturistaRepository
    {
        public Faturista BuscarFaturistaPorUsuarioId(int usuarioId);
        bool Deletar(int id);
        IEnumerable<Faturista> BuscarTodosFaturistas();
        Faturista BuscarFaturistaPorId(int id);
    }
}
