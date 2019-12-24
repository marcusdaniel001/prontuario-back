using Microsoft.EntityFrameworkCore;
using Prontuario.Domain.Entities;
using Prontuario.Infra.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prontuario.Infra.Data.Context
{
	public class PostgresContext : DbContext
	{
		public DbSet<Usuario> Usuario { get; set; }
		public DbSet<Telefone> Telefone { get; set; }
		public DbSet<Endereco> Endereco { get; set; }
		public DbSet<Paciente> Paciente { get; set; }
		public DbSet<PlanoSaude> PlanoSaude { get; set; }

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
