﻿namespace Prontuario.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string Senha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
