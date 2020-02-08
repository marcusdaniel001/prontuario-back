using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface ILocalAtendimentoRepository
    {
        bool Deletar(int id);
        IEnumerable<LocalAtendimento> BuscarTodosLocaisAtendimentos();
        LocalAtendimento BuscarLocalAtendimentoPorId(int id);
    }
}
