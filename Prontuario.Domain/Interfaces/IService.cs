using Prontuario.Domain.Entities;
using System.Collections.Generic;

namespace Prontuario.Domain.Interfaces
{
	public interface IService<T> where T : BaseEntity
	{
		T Post<V>(T obj);

		T Put<V>(T obj);

		void Delete(int id);

		T Get(int id);

		IList<T> Get();
	}
}
