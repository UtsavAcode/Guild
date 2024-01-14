using Guild.Data;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Guild.Repository
{
    //Using T to make the class generic as well 
    public class WorkerRepository<T> : IRepository<T> where T : class
    {
        //Using dependency injection
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        //Creating a constructor.
        public WorkerRepository( ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable < T > query = dbSet;
            query = query.Where(filter);
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
