using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly PostgresContext _contexto;

        public AgendaRepository()
        {
            _contexto = new PostgresContext();
        }

        public Agenda BuscarAgendaInicioFim(Agenda agenda)
        {
            var agendas = BuscarTodasAgendas().FirstOrDefault(p => p.Inicio < agenda.Inicio && p.Fim > agenda.Fim);

            return agendas;
        }

        public bool Deletar(int id)
        {
            var paciente = _contexto.Pacientes.Single(p => p.Id == id);

            if (paciente == null) return false;

            _contexto.Remove(paciente);
            _contexto.SaveChanges();
            return true;
        }

        public Agenda BuscarAgendaPorId(int id)
        {
            return BuscarTodasAgendas().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Agenda> BuscarTodasAgendas()
        {
            var query =
                from a in _contexto.Agenda
                join m in _contexto.Medicos on a.MedicoId equals m.Id
                join s in _contexto.Secretarias on a.SecretariaId equals s.Id
                join p in _contexto.Pacientes on a.PacienteId equals p.Id
                join usuarioMedico in _contexto.Usuarios on m.UsuarioId equals usuarioMedico.Id
                join usuarioSecretaria in _contexto.Usuarios on s.UsuarioId equals usuarioSecretaria.Id
                join usuarioPaciente in _contexto.Usuarios on p.UsuarioId equals usuarioPaciente.Id
                join planoSaudePaciente in _contexto.PlanosSaude on usuarioPaciente.PlanoSaudeId equals planoSaudePaciente.Id
                select new Agenda
                {
                    Id = a.Id,
                    Inicio = a.Inicio,
                    Fim = a.Fim,
                    Paciente = new Paciente
                    {
                        Id = p.Id,
                        Usuario = new Usuario
                        {
                            Id = usuarioPaciente.Id,
                            Nome = usuarioPaciente.Nome,
                            PlanoSaude = new PlanoSaude
                            {
                                Id = planoSaudePaciente.Id,
                                Nome = planoSaudePaciente.Nome,
                                Numero = planoSaudePaciente.Numero
                            }
                        }
                    },
                    Medico = new Medico
                    {
                        Id = m.Id,
                        EspecialidadesMedicas = m.EspecialidadesMedicas,
                        Usuario = new Usuario
                        {
                            Id = usuarioMedico.Id,
                            Nome = usuarioMedico.Nome
                        }
                    },
                    Secretaria = new Secretaria
                    {
                        Id = s.Id,
                        Usuario = new Usuario
                        {
                            Id = usuarioSecretaria.Id,
                            Nome = usuarioSecretaria.Nome
                        }
                    }
                };

            return query;
        }

    }
}
