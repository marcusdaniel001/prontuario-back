using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces.Repositories;
using Prontuario.Infra.Data.Context;

namespace Prontuario.Infra.Data.Repository
{
    public class LocalAtendimentoRepository : ILocalAtendimentoRepository
    {
        private readonly PostgresContext _contexto;

        public LocalAtendimentoRepository()
        {
            _contexto = new PostgresContext();
        }

        public bool Deletar(int id)
        {
            var localAtendimento = _contexto.LocalAtendimentos.Single(p => p.Id == id);

            if (localAtendimento == null) return false;

            _contexto.Remove(localAtendimento);
            _contexto.SaveChanges();
            return true;
        }

        public LocalAtendimento BuscarLocalAtendimentoPorId(int id)
        {
            return BuscarTodosLocaisAtendimentos().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<LocalAtendimento> BuscarTodosLocaisAtendimentos()
        {
            var query =
                from l in _contexto.LocalAtendimentos
                join end in _contexto.Enderecos on l.EnderecoId equals end.Id
                join tel in _contexto.Telefones on l.TelefoneId equals tel.Id
                select new LocalAtendimento
                {
                    Id = l.Id,
                    Nome = l.Nome,
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
                    Telefone = new Telefone
                    {
                        Id = tel.Id,
                        Numero = tel.Numero
                    }
                };

            return query;
        }
    }
}
