using Guild.Models.Domain;

namespace Guild.Repository.IRepository
{
    public interface IWorkerRepository : IRepository<worker>
    {
        void Update(worker model);
        void Save();
    }
}
