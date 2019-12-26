﻿namespace Prontuario.Domain.Entities
{
    public class Telefone : BaseEntity
    {
        public string Numero { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LocalAtendimentoId { get; set; }
        public LocalAtendimento LocalAtendimento { get; set; }
    }
}
