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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseNpgsql("Server=localhost;Port=5432;user id=postgres; password = 123; database = prontuariolegal");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
		}
	}
}
