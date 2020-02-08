using System;
using System.Collections.Generic;
using System.Text;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        bool Criar(Usuario usuario);
        bool Atualizar(Usuario usuario);
        bool Deletar(int id);
        IEnumerable<Usuario> BuscarTodosUsuarios();
        Usuario BuscarUsuarioPorId(int id);
        Usuario BuscarUsuarioPorCpf(string cpf);
    }
}
