using Guild.Data;
using Guild.Models.Domain;
using Guild.Repository.IRepository;

namespace Guild.Repository.Implementation
{
    public class WorkerRepository : Repository<worker>, IWorkerRepository
    {
        private ApplicationDbContext _workerContext;

        public WorkerRepository(ApplicationDbContext workerContext) : base (workerContext) 
        {
            _workerContext = workerContext;
        }
        public void Save()
        {
          _workerContext.SaveChanges();
        }

        public void Update(worker model)
        {
           _workerContext.Workers?.Update(model);
        }
    }
}
