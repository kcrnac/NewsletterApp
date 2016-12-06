using Newsletter.Model.Base;
using System;
using System.Data.Entity;
using System.Linq;

namespace Newsletter.DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryBase(NewsletterDbContext context)
        {
            Context = context;
        }

        protected NewsletterDbContext Context { get; set; }

        public IQueryable<T> All
        {
            get
            {
                return Context.Set<T>();
            }
        }

        public T Find(string id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(string id)
        {
            var obj = Find(id);

            Context.Set<T>().Remove(obj);
            Context.SaveChanges();
        }
    }
}
