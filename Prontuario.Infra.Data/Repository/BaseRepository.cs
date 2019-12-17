using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces;
using Prontuario.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Prontuario.Infra.Data.Repository
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		private PostgresContext context = new PostgresContext();

		public void Insert(T obj)
		{
			context.Set<T>().Add(obj);
			context.SaveChanges();
		}

		public void Update(T obj)
		{
			context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			context.Set<T>().Remove(Select(id));
			context.SaveChanges();
		}

		public IList<T> Select()
		{
			return context.Set<T>().ToList();
		}

		public T Select(int id)
		{
			return context.Set<T>().Find(id);
		}
	}
}
