using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface IAgendaService
    {
        bool Criar(Agenda agenda);
        bool Atualizar(Agenda agenda);
        bool Deletar(int id);
        IEnumerable<Agenda> BuscarTodasAgendas();
        Agenda BuscarAgendaPorId(int id);
    }
}
