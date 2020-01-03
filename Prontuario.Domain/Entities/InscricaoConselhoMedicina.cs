using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class InscricaoConselhoMedicina : BaseEntity
    {
        public string Numero { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
