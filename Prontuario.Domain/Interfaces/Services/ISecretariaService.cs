using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface ISecretariaService
    {
        bool Criar(Secretaria secretaria);
        bool Atualizar(Secretaria secretaria);
        bool Deletar(int id);
        IEnumerable<Secretaria> BuscarTodasSecretarias();
        Secretaria BuscarSecretariaPorId(int id);
    }
}
