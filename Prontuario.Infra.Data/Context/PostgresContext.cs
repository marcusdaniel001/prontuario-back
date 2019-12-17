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
		public DbSet<User> User { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseNpgsql("Server=[SERVIDOR];Port=[PORTA];Database=modelo;Uid=[USUARIO];Pwd=[SENHA]");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(new UserMap().Configure);
		}
	}
}
