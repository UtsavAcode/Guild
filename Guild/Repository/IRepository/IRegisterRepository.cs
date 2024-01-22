using Guild.Models;
using Guild.Models.Domain;

namespace Guild.Repository.IRepository
{
    public interface IRegisterRepository: IRepository<Worker>
    {
        void Update(Worker update);
        /*void FindByEmail(string Email);*/
        void Save();
    }
}
