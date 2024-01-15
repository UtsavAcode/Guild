using Guild.Models;
using Guild.Models.Domain;

namespace Guild.Repository.IRepository
{
    //Now the class we will be using is the model that we want to use for the repository.
    public interface IWorkerRepository : IRepository<worker>
    {
        void Update(worker obj);
        void Save();
    }
}
