using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class Medico : BaseEntity
    {
        public string Senha { get; set; }
        public string EspecialidadesMedicas { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
