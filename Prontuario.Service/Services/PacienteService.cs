using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class PacienteService : IPacienteService
    {
        private BaseRepository<Usuario> repositoryUsuario = new BaseRepository<Usuario>();
        private BaseRepository<Paciente> repositoryPaciente = new BaseRepository<Paciente>();
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public bool Criar(Paciente paciente)
        {
            var pacienteAuxiliar = new Paciente();

            if(paciente.Usuario.Id != 0)
            {
                var pacienteExistente = _pacienteRepository.BuscarPacientePorUsuarioId(paciente.Usuario.Id);

                // Se houver paciente para este Id de usuario eu preciso retornar e nao fazer nada
                if (pacienteExistente != null)
                {
                    return false;
                }
                else
                {
                    pacienteAuxiliar.Senha = paciente.Senha;
                    pacienteAuxiliar.UsuarioId = paciente.Usuario.Id;

                    repositoryPaciente.Insert(pacienteAuxiliar);
                    return true;
                }

            }

            repositoryPaciente.Insert(paciente);
            return true;
        }

        public IEnumerable<Paciente> BuscarTodosPacientes()
        {
            return _pacienteRepository.BuscarTodosPacientes();
        }

        public Paciente BuscarPacientePorId(int id)
        {
            return _pacienteRepository.BuscarPacientePorId(id);
        }
    }
}
