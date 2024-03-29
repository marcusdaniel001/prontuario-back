﻿using Prontuario.Domain.Entities;
using System.Collections.Generic;

namespace Prontuario.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        //void Remove(int id);

        T Select(int id);

        IList<T> Select();
    }
}
