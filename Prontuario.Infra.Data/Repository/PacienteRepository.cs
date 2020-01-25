using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {

        public Paciente BuscarPacientePorUsuarioId(int usuarioId)
        {
            using var context = new PostgresContext();

            var query = from p in context.Pacientes
                where p.Usuario.Id == usuarioId
                select new Paciente
                {
                    Id = p.Id,
                    Senha = p.Senha,
                    Usuario = p.Usuario
                };

            return query.FirstOrDefault();
        }
    }
}
