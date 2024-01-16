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

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        //This is the class to get the data by id.

        public worker GetById(int Id)
        {
            return applicationDbContext.Workers.FirstOrDefault(x => x.Id == Id);
        }

        //This is the class to delete the data by using the id in the database of the workers.

        public void DeleteById(int Id)
        {
            var worker = GetById(Id);

            if (worker !=null && worker.Id==Id)
            {
                applicationDbContext.Workers.Remove(worker);    
                applicationDbContext.SaveChanges();
            }
           
        }
    }
}
