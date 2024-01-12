//This class will implement all the method in the worker interface.
//This class will be generic to store different kinds of data.

using Guild.Data;
using Microsoft.EntityFrameworkCore;

namespace Guild.Controllers.Repository
{
    public class WorkerRepository<T> : IWorkerRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> dbSet;
        public WorkerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<T>();
           

        }

        public void DeleteDataById(int Id)
        {

            T model = dbSet.Find(Id);
            dbSet.Remove(model);
        }

        public IEnumerable<T> GetData()
        {
            return dbSet.ToList();
        }

        public T GetDataById(int Id)
        {

            return dbSet.Find(Id); 
        }

        public void InsertData(T Classname)
        {

            dbSet.Add(Classname);
        }

        public void SaveData()
        {
           _applicationDbContext.SaveChanges();
        }

        public void UpdateDataById(T Classname)
        {
            dbSet.Entry(Classname).State = EntityState.Modified();
        }
    }
}
