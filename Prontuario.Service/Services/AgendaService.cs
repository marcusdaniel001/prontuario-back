using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly BaseRepository<Agenda> _repositoryAgenda = new BaseRepository<Agenda>();
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public bool Criar(Agenda agenda)
        {
            var agendaExistente = _agendaRepository.BuscarAgendaInicioFim(agenda);

            // Se houver paciente para este Id de usuario eu preciso retornar e nao fazer nada
            if (agendaExistente != null)
            {
                return false;
            }

            _repositoryAgenda.Insert(agenda);
            return true;
        }

        public bool Atualizar(Agenda agenda)
        {
            return true;
        }

        public bool Deletar(int id)
        {
            return _agendaRepository.Deletar(id);
        }

        public IEnumerable<Agenda> BuscarTodasAgendas()
        {
            return _agendaRepository.BuscarTodasAgendas();
        }

        public Agenda BuscarAgendaPorId(int id)
        {
            return _agendaRepository.BuscarAgendaPorId(id);
        }
    }
}
