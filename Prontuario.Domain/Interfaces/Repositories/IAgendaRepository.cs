using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        Agenda BuscarAgendaInicioFim(Agenda agenda);
        bool Deletar(int id);
        IEnumerable<Agenda> BuscarTodasAgendas();
        Agenda BuscarAgendaPorId(int id);
    }
}
