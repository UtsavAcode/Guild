using Guild.Data;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Guild.Repository.Implementation
{
    public class Repository<T> : IRepository<T>  where T : class
    {

       private readonly ApplicationDbContext _repository;
        internal DbSet<T> database;
        public Repository(ApplicationDbContext repository)
        {
            _repository = repository;

            database = _repository.Set<T>();
        }

        public void Add(T entity)
        {
            database.Add(entity);
        }

        public void Delete(T entity)
        {
            database.Remove(entity);
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
            return query.ToList().Select(item =>
            {
                if(item is Worker worker)
                {
                    worker.Address = worker.Address ?? "";
                }
                return item;
            });
        }
        
       

      

        public T FindById(int Id)
        {
            DbSet<T>? query = database;
            return query.Find(Id);
        }
    }
}
