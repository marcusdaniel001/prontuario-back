using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface IFaturistaService
    {
        bool Criar(Faturista paciente);
        bool Atualizar(Faturista paciente);
        bool Deletar(int id);
        IEnumerable<Faturista> BuscarTodosFaturistas();
        Faturista BuscarFaturistaPorId(int id);
    }
}
