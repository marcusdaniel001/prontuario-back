using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prontuario.Domain.Entities
{
    public class Agenda : BaseEntity
    {
        public DateTime Inicio { get; set; }
        [NotMapped]
        public string InicioString { get; set; }
        public DateTime Fim { get; set; }
        [NotMapped]
        public string FimString { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int SecretariaId { get; set; }
        public Secretaria Secretaria { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
