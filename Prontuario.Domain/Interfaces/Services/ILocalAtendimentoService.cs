using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface ILocalAtendimentoService
    {
        bool Criar(LocalAtendimento localAtendimento);
        bool Atualizar(LocalAtendimento localAtendimento);
        bool Deletar(int id);
        IEnumerable<LocalAtendimento> BuscarTodosLocaisAtendimentos();
        LocalAtendimento BuscarLocalAtendimentoPorId(int id);
    }
}
