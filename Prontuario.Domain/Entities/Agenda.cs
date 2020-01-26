using System;

namespace Prontuario.Domain.Entities
{
    public class Agenda : BaseEntity
    {
        public DateTime Incio { get; set; }
        public DateTime Fim { get; set; }
        public string Presintomas { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int SecretariaId { get; set; }
        public Secretaria Secretaria { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
