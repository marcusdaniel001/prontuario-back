using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string Senha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int PlanoSaudeId { get; set; }
        public PlanoSaude PlanoSaude { get; set; }
    }
}
