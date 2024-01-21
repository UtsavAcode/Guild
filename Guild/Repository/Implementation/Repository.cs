using Guild.Data;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T>  where T : class
    {

       private readonly ApplicationDbContext _repository;
        public DbSet<T> dbSet;
        public Repository(ApplicationDbContext repository)
        {
            _repository = repository;

            this.dbSet = _repository.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }
    }
}
