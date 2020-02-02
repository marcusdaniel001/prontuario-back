using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface ISecretariaRepository
    {
        public Secretaria BuscarSecretariaPorUsuarioId(int usuarioId);
        bool Deletar(int id);
        IEnumerable<Secretaria> BuscarTodasSecretarias();
        Secretaria BuscarSecretariaPorId(int id);
    }
}
