using Guild.Data;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T>  where T : class
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
        public void Delete(T entity)
        {
            _context.Remove(entity);
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
            IQueryable<T> query = database;
            return query.ToList();
        }

     
    }
}
