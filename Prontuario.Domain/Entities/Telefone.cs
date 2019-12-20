using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        public string Fixo { get; set; }
        public string Celular { get; set; }
    }
}
