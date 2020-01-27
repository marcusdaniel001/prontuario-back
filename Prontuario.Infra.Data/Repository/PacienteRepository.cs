using System.Collections.Generic;
using System.Linq;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly PostgresContext _contexto;

        public PacienteRepository()
        {
            _contexto = new PostgresContext();
        }

        public Paciente BuscarPacientePorUsuarioId(int usuarioId)
        {

            var query = from p in _contexto.Pacientes
                where p.Usuario.Id == usuarioId
                select new Paciente
                {
                    Id = p.Id,
                    Senha = p.Senha,
                    Usuario = p.Usuario
                };

            return query.FirstOrDefault();
        }

        public bool Deletar(int id)
        {
            var paciente = _contexto.Pacientes.Single(p => p.Id == id);

            if (paciente == null) return false;

            _contexto.Remove(paciente);
            _contexto.SaveChanges();
            return true;
        }

        public Paciente BuscarPacientePorId(int id)
        {
            return BuscarTodosPacientes().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Paciente> BuscarTodosPacientes()
        {
            var query =
                from p in _contexto.Pacientes
                join u in _contexto.Usuarios on p.Usuario.Id equals u.Id
                join end in _contexto.Enderecos on u.EnderecoId equals end.Id
                join plan in _contexto.PlanosSaude on u.PlanoSaudeId equals plan.Id
                select new Paciente
                {
                    Id = p.Id,
                    Senha = p.Senha,
                    Usuario = new Usuario
                    {
                        Id = u.Id,
                        Cpf = u.Cpf,
                        DataNascimento = u.DataNascimento,
                        Sexo = u.Sexo,
                        NomeMae = u.NomeMae,
                        MidiasSociais = u.MidiasSociais,
                        Endereco = new Endereco
                        {
                            Id = end.Id,
                            Rua = end.Rua,
                            Numero = end.Numero,
                            Complemento = end.Complemento,
                            Bairro = end.Bairro,
                            Cidade = end.Cidade,
                            Estado = end.Estado,
                            Pais = end.Pais,
                            Cep = end.Cep
                        },
                        PlanoSaude = new PlanoSaude
                        {
                            Id = plan.Id,
                            Nome = plan.Nome,
                            Numero = plan.Numero
                        }
                    }
                };

            return query;
        }
    }
}
