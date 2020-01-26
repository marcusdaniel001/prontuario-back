﻿namespace Prontuario.Domain.Entities
{
    public class LocalAtendimento : BaseEntity
    {
        //Nome do local de atendimento
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
