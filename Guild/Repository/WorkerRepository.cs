using Guild.Data;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Guild.Repository
{
    //Using T to make the class generic as well 
    public class WorkerRepository<T> : IRepository<T> where T : class
    {
        //Using dependency injection
        private readonly ApplicationDbContext applicationDbContext;
        internal DbSet<T> dbSet;
        //Creating a constructor.
        public WorkerRepository( ApplicationDbContext db)
        {
            applicationDbContext = db;
            this.dbSet = applicationDbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable < T > query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

      

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

       

    }
}
