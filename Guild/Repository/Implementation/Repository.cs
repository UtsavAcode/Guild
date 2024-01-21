using Guild.Data;
using Guild.Repository.IRepository;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T>  where T : class
    {

        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
             _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
          _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetEnumerable()
        {
           return _context.Set<T>().AsEnumerable();
        }

        public void Insert(T entity)
        {
           _context.Set<T>().Add(entity);
           _context.SaveChanges();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();  
        }
    }
}
