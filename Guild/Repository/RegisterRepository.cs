using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace Guild.Repository
{
    public class RegisterRepository : WorkerRepository<worker>, IWorkerRepository
    {
        private ApplicationDbContext applicationDbContext;
        public RegisterRepository(ApplicationDbContext db) : base(db)
        {
            applicationDbContext = db;
        }
        public void Save()
        {
            applicationDbContext.SaveChanges();
        }

        public void Update(worker obj)
        {

            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "The object to update cannot be null.");
            }

            applicationDbContext.Workers.Update(obj);
        }//


        //This is the class to get the data by id.

        public worker GetById(int Id)
        {
            return applicationDbContext.Workers.FirstOrDefault(x => x.Id == Id);
        }

        //This is the class to delete the data by using the id in the database of the workers.

        public void DeleteById(int Id)
        {
            var worker = GetById(Id);

            if (worker != null && worker.Id == Id)
            {
                applicationDbContext.Workers.Remove(worker);
                applicationDbContext.SaveChanges();
            }

        }
    }
}
