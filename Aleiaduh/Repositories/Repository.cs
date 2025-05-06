using Aleiaduh.DataAccess;
using Aleiaduh.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Aleiaduh.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly ApplicationDbContext applicationDb;
        public DbSet<T> dbset;
        public Repository(ApplicationDbContext applicationDb)
        {
            this.applicationDb = applicationDb;
            dbset = applicationDb.Set<T>();
        }
        public void Create(T entity)
        {
            dbset.Add(entity);
        }
        public void Create(List<T> entities)
        {
            dbset.AddRange(entities);
        }
        public void Update(T entity)
        {
            dbset.Update(entity);
        }
        public void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        public void Commit()
        {
            applicationDb.SaveChanges();
        }
        
        public IEnumerable<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>?[] includes=null,bool tracked=true)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public T? GetOne(Expression<Func<T, bool>>? filter = null, Expression<Func<T, object>>?[]
            includes = null, bool tracked = true)
        {
            return Get(filter, includes, tracked).FirstOrDefault();
        }

    }
}
