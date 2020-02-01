using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class FaturistaService : IFaturistaService
    {
        private readonly BaseRepository<Usuario> _repositoryUsuario = new BaseRepository<Usuario>();
        private readonly BaseRepository<Faturista> _repositoryEntityFaturista = new BaseRepository<Faturista>();
        private readonly IFaturistaRepository _faturistaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public FaturistaService(IFaturistaRepository faturistaRepository, IUsuarioRepository usuarioRepository)
        {
            _faturistaRepository = faturistaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public bool Criar(Faturista faturista)
        {
            var faturistaAuxiliar = new Faturista();

            if (faturista.Usuario.Id != 0)
            {
                var faturistaExistente = _faturistaRepository.BuscarFaturistaPorUsuarioId(faturista.Usuario.Id);

                // Se houver paciente para este Id de usuario eu preciso retornar e nao fazer nada
                if (faturistaExistente != null)
                {
                    return false;
                }

                faturistaAuxiliar.Senha = faturista.Senha;
                faturistaAuxiliar.UsuarioId = faturista.Usuario.Id;

                _repositoryEntityFaturista.Insert(faturistaAuxiliar);
                return true;
            }

            _repositoryEntityFaturista.Insert(faturista);
            return true;
        }

        public bool Atualizar(Faturista faturista)
        {
            _repositoryUsuario.Update(faturista.Usuario);
            _repositoryEntityFaturista.Update(faturista);
            //Fazer o metodo atualizar que ta sendo o mais chatim
            return true;
        }

        public bool Deletar(int id)
        {
            return _faturistaRepository.Deletar(id);
        }

        public IEnumerable<Faturista> BuscarTodosFaturistas()
        {
            return _faturistaRepository.BuscarTodosFaturistas();
        }

        public Faturista BuscarFaturistaPorId(int id)
        {
            return _faturistaRepository.BuscarFaturistaPorId(id);
        }
    }
}
