using Prontuario.Domain.Entities;
using Prontuario.Domain.Interfaces;
using Prontuario.Infra.Data.Repository;
using System;
using System.Collections.Generic;

namespace Prontuario.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Post<V>(T obj)
        {
            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj)
        {
            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }
    }
}
