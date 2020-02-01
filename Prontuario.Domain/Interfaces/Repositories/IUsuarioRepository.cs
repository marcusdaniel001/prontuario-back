using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuarioPorCpf(string cpf);
    }
}
