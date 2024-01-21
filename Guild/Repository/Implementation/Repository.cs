using Guild.Data;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T>  where T : class
    {

        private readonly ApplicationDbContext _context;
        public DbSet<T> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _context.SaveChanges();
        }

       

        public void DeleteRange(IEnumerable<T> entities)
        {
          _context.RemoveRange(entities);
            _context.SaveChanges();
        }

     

        public void InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

     
    }
}
