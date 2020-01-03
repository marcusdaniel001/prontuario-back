using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class LocalAtendimentoMedico : BaseEntity
    {
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int LocalAtendimentoId { get; set; }
        public LocalAtendimento LocalAtendimento { get; set; }
    }
}
