using Guild.Models;
using Guild.Models.Domain;

namespace Guild.Repository.IRepository
{
    public interface IRegisterRepository: IRepository<Worker>
    {
        void Add(Worker worker);
        void Add(Register register);
        void Save();
    }
}
