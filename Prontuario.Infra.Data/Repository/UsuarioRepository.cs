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
            return BuscarTodosUsuarios().FirstOrDefault(u => u.Cpf == cpf);
        }

        public bool Deletar(int id)
        {
            var usuario = _contexto.Usuarios.Single(u => u.Id == id);

            if (usuario == null) return false;

            _contexto.Remove(usuario);
            _contexto.SaveChanges();
            return true;
        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return BuscarTodosUsuarios().FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Usuario> BuscarTodosUsuarios()
        {
            var query =
                from u in _contexto.Usuarios
                join end in _contexto.Enderecos on u.EnderecoId equals end.Id
                join plan in _contexto.PlanosSaude on u.PlanoSaudeId equals plan.Id
                join t in _contexto.Telefones on u.TelefoneId equals t.Id
                select new Usuario
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
                };

            return query;
        }
    }
}
