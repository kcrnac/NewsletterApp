using System;
using System.Linq;

namespace Newsletter.Model.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> All { get; }

        T Find(string id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(string id);

    }
}
