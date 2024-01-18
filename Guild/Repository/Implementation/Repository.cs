using Guild.Data;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        internal DbSet<T> database;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            database = _context.Set<T>();
        }
        public void Add(T entity)
        {
            database.Add(entity);
        }

        public T FindById(int id)
        {
            DbSet<T>? query = database;
            return query.Find(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = database;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = database;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            database.Remove(entity);  
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            database.RemoveRange(entities);
        }
    }
}
