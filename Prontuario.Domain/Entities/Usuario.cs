using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prontuario.Domain.Entities
{
	public class Usuario : BaseEntity
	{
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		[NotMapped]
        public string DataNascimentoString { get; set; }
		public string Sexo { get; set; }
		public string NomeMae { get; set; }
		public string Cpf { get; set; }
		public string MidiasSociais { get; set; }
		public int EnderecoId { get; set; }
		public Endereco Endereco { get; set; }
		public int PlanoSaudeId { get; set; }
		public PlanoSaude PlanoSaude { get; set; }
	}
}
