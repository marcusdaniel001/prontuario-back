using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class PlanoSaude : BaseEntity
    {
        public string Nome { get; set; }
        public string Numero { get; set; }
    }
}
