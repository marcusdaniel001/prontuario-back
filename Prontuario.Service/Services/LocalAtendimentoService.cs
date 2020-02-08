using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class LocalAtendimentoService : ILocalAtendimentoService
    {
        private readonly BaseRepository<LocalAtendimento> _repositoryLocalAtendimento = new BaseRepository<LocalAtendimento>();
        private readonly ILocalAtendimentoRepository _localAtendimentoRepository;

        public LocalAtendimentoService(ILocalAtendimentoRepository localAtendimentoRepository)
        {
            _localAtendimentoRepository = localAtendimentoRepository;
        }

        public bool Criar(LocalAtendimento localAtendimento)
        {
            _repositoryLocalAtendimento.Insert(localAtendimento);
            return true;
        }

        public bool Atualizar(LocalAtendimento localAtendimento)
        {
            //Fazer o metodo atualizar que ta sendo o mais chatim
            return true;
        }

        public bool Deletar(int id)
        {
            return _localAtendimentoRepository.Deletar(id);
        }

        public IEnumerable<LocalAtendimento> BuscarTodosLocaisAtendimentos()
        {
            return _localAtendimentoRepository.BuscarTodosLocaisAtendimentos();
        }

        public LocalAtendimento BuscarLocalAtendimentoPorId(int id)
        {
            return _localAtendimentoRepository.BuscarLocalAtendimentoPorId(id);
        }
    }
}
