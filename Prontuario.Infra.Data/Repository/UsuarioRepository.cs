using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PostgresContext _contexto;

        public UsuarioRepository()
        {
            _contexto = new PostgresContext();
        }

        public Usuario BuscarUsuarioPorCpf(string cpf)
        {
            var query = from u in _contexto.Usuarios
                join end in _contexto.Enderecos on u.EnderecoId equals end.Id
                join plan in _contexto.PlanosSaude on u.PlanoSaudeId equals plan.Id
                join t in _contexto.Telefones on u.TelefoneId equals t.Id
                where u.Cpf == cpf
                select new Usuario
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
                };

            return query.FirstOrDefault();
        }
    }
}
