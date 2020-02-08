using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class SecretariaService : ISecretariaService
    {
        private readonly BaseRepository<Usuario> _repositoryUsuario = new BaseRepository<Usuario>();
        private readonly BaseRepository<Secretaria> _repositorySecretaria = new BaseRepository<Secretaria>();
        private readonly ISecretariaRepository _secretariaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public SecretariaService(ISecretariaRepository secretariaRepository, IUsuarioRepository usuarioRepository)
        {
            _secretariaRepository = secretariaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public bool Criar(Secretaria secretaria)
        {
            var secretariaAuxiliar = new Secretaria();

            if (secretaria.Usuario.Id != 0)
            {
                var pacienteExistente = _secretariaRepository.BuscarSecretariaPorUsuarioId(secretaria.Usuario.Id);

                // Se houver paciente para este Id de usuario eu preciso retornar e nao fazer nada
                if (pacienteExistente != null)
                {
                    return false;
                }

                secretariaAuxiliar.Senha = secretaria.Senha;
                secretariaAuxiliar.UsuarioId = secretaria.Usuario.Id;

                _repositorySecretaria.Insert(secretariaAuxiliar);
                return true;
            }

            _repositorySecretaria.Insert(secretaria);
            return true;
        }

        public bool Atualizar(Secretaria secretaria)
        {
            return true;
        }

        public bool Deletar(int id)
        {
            return _secretariaRepository.Deletar(id);
        }

        public IEnumerable<Secretaria> BuscarTodasSecretarias()
        {
            return _secretariaRepository.BuscarTodasSecretarias();
        }

        public Secretaria BuscarSecretariaPorId(int id)
        {
            return _secretariaRepository.BuscarSecretariaPorId(id);
        }
    }
}
