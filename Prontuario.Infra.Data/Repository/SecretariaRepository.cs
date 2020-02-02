using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class SecretariaRepository : ISecretariaRepository
    {
        private readonly PostgresContext _contexto;

        public SecretariaRepository()
        {
            _contexto = new PostgresContext();
        }

        public Secretaria BuscarSecretariaPorUsuarioId(int usuarioId)
        {
            return BuscarTodasSecretarias().FirstOrDefault(s => s.Usuario.Id == usuarioId);
        }

        public bool Deletar(int id)
        {
            var secretaria = _contexto.Secretarias.Single(p => p.Id == id);

            if (secretaria == null) return false;

            _contexto.Remove(secretaria);
            _contexto.SaveChanges();
            return true;
        }

        public Secretaria BuscarSecretariaPorId(int id)
        {
            return BuscarTodasSecretarias().FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Secretaria> BuscarTodasSecretarias()
        {
            var query =
                from s in _contexto.Secretarias
                join u in _contexto.Usuarios on s.Usuario.Id equals u.Id
                join end in _contexto.Enderecos on u.EnderecoId equals end.Id
                join plan in _contexto.PlanosSaude on u.PlanoSaudeId equals plan.Id
                join t in _contexto.Telefones on u.TelefoneId equals t.Id
                select new Secretaria
                {
                    Id = s.Id,
                    Senha = s.Senha,
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
