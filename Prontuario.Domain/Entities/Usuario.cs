using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Domain.Entities
{
	public class Usuario : BaseEntity
	{
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Sexo { get; set; }
		public string NomeMae { get; set; }
		public string Cpf { get; set; }
		public string MidiasSociais { get; set; }
		public int EnderecoId { get; set; }
		public Endereco Endereco { get; set; }
		public int TelefoneId { get; set; }
		public Telefone Telefone { get; set; }
	}
}
