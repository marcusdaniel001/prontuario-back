using System.Collections.Generic;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Services
{
    public interface IPacienteService
    {
        public bool Criar(Paciente paciente);
        IEnumerable<Paciente> BuscarTodosPacientes();
        Paciente BuscarPacientePorId(int id);
    }
}
