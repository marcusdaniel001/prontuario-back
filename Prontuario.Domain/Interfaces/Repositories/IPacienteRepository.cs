using System.Collections.Generic;
using Prontuario.Domain.Entities;

namespace Prontuario.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        public Paciente BuscarPacientePorUsuarioId(int usuarioId);
        bool Deletar(int id);
        IEnumerable<Paciente> BuscarTodosPacientes();
        Paciente BuscarPacientePorId(int id);
    }
}
