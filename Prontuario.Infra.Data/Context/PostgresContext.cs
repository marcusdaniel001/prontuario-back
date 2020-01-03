using Microsoft.EntityFrameworkCore;
using Prontuario.Domain.Entities;
using Prontuario.Infra.Data.Mapping;

namespace Prontuario.Infra.Data.Context
{
	public class PostgresContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Telefone> Telefones { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Paciente> Pacientes { get; set; }
		public DbSet<PlanoSaude> PlanosSaude { get; set; }
		public DbSet<LocalAtendimento> LocalAtendimentos { get; set; }
		public DbSet<Secretaria> Secretarias { get; set; }
		public DbSet<Faturista> Faturistas { get; set; }
		public DbSet<Medico> Medicos { get; set; }
		public DbSet<InscricaoConselhoMedicina> InscricaoConselhosMedicina { get; set; }
		public DbSet<LocalAtendimentoMedico> LocalAtendimentoMedico { get; set; }
		public DbSet<Agenda> Agenda { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseNpgsql("Server=localhost;Port=5433;user id=postgres; password = 123; database = prontuariolegal");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
		}
	}
}
