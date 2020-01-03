using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prontuario.Domain.Entities;

namespace Prontuario.Infra.Data.Mapping
{
	public class UsuarioMap : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuarios");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasColumnName("Nome");

			builder.Property(c => c.DataNascimento)
				.IsRequired()
				.HasColumnName("DataNascimento");

			builder.Property(c => c.Sexo)
				.IsRequired()
				.HasColumnName("Sexo");

			builder.Property(c => c.NomeMae)
				.IsRequired()
				.HasColumnName("NomeMae");

			builder.Property(c => c.Cpf)
				.IsRequired()
				.HasColumnName("Cpf");

			builder.Property(c => c.MidiasSociais)
				.IsRequired()
				.HasColumnName("MidiasSociais");

			builder.Property(c => c.EnderecoId)
				.IsRequired()
				.HasColumnName("EnderecoId");

			builder.Property(c => c.PlanoSaudeId)
				.IsRequired()
				.HasColumnName("PlanoSaudeId");
		}
	}
}
