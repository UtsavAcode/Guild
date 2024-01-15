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
    }
}
