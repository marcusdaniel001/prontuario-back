using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class FaturistaRepository : IFaturistaRepository
    {
        private readonly PostgresContext _contexto;

        public FaturistaRepository()
        {
            _contexto = new PostgresContext();
        }

        public Faturista BuscarFaturistaPorUsuarioId(int usuarioId)
        {
            return BuscarTodosFaturistas().FirstOrDefault(f => f.Usuario.Id == usuarioId);
        }

        public bool Deletar(int id)
        {
            var faturista = _contexto.Pacientes.Single(f => f.Id == id);

            if (faturista == null) return false;

            _contexto.Remove(faturista);
            _contexto.SaveChanges();
            return true;
        }

        public Faturista BuscarFaturistaPorId(int id)
        {
            return BuscarTodosFaturistas().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Faturista> BuscarTodosFaturistas()
        {
            var query =
                from f in _contexto.Faturistas
                join u in _contexto.Usuarios on f.Usuario.Id equals u.Id
                join end in _contexto.Enderecos on u.EnderecoId equals end.Id
                join plan in _contexto.PlanosSaude on u.PlanoSaudeId equals plan.Id
                join t in _contexto.Telefones on u.TelefoneId equals t.Id
                select new Faturista
                {
                    Id = f.Id,
                    Senha = f.Senha,
                    Usuario = new Usuario
                    {
                        Id = u.Id,
                        Nome = u.Nome,
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
                        },
                        Telefone = new Telefone
                        {
                            Id = t.Id,
                            Numero = t.Numero
                        }
                    }
                };

            return query;
        }
    }
}
