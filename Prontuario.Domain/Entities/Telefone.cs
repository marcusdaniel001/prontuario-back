﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        public string Numero { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
