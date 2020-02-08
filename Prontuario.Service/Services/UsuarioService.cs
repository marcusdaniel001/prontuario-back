using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class UsuarioService : IUsuarioService
    { 
        private readonly BaseRepository<Usuario> _repositoryUsuario = new BaseRepository<Usuario>();
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Criar(Usuario usuario)
        {
            var pacienteExistente = _usuarioRepository.BuscarUsuarioPorCpf(usuario.Cpf);

            // Se houver paciente para este Id de usuario eu preciso retornar e nao fazer nada
            if (pacienteExistente != null)
            {
                return false;
            }

            _repositoryUsuario.Insert(usuario);
            return true;
        }

        public bool Atualizar(Usuario usuario)
        {
            return true;
        }

        public bool Deletar(int id)
        {
            return _usuarioRepository.Deletar(id);
        }

        public IEnumerable<Usuario> BuscarTodosUsuarios()
        {
            return _usuarioRepository.BuscarTodosUsuarios();
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public Usuario BuscarUsuarioPorCpf(string cpf)
        {
            return _usuarioRepository.BuscarUsuarioPorCpf(cpf);
        }
    }
}
