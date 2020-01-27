using System.Collections.Generic;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        bool Criar(Paciente paciente);
        bool Atualizar(Paciente paciente);
        bool Deletar(int id);
        IEnumerable<Paciente> BuscarTodosPacientes();
        Paciente BuscarPacientePorId(int id);
    }
}
