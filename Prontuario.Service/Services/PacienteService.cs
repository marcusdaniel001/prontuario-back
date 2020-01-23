using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Services;
using Prontuario.Infra.Data.Repository;

namespace Prontuario.Service.Services
{
    public class PacienteService : IPacienteService
    {
        private BaseRepository<Usuario> repositoryUsuario = new BaseRepository<Usuario>();
        private BaseRepository<Paciente> repositoryPaciente = new BaseRepository<Paciente>();

        public void Criar(Paciente paciente)
        {
            var usuarioExistente = repositoryUsuario.Select(paciente.Usuario.Id);

            if(usuarioExistente != null && usuarioExistente.Id != 0)
            {
                paciente = new Paciente
                {
                    Id = paciente.Id,
                    Senha = paciente.Senha,
                    UsuarioId = usuarioExistente.Id
                };
            }

            repositoryPaciente.Insert(paciente);
        }
    }
}
