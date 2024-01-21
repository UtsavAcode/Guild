using Guild.Models;

namespace Guild.Repository.IRepository
{
    public interface IRegisterRepository: IRepository<Register>
    {
        void Add(Register register);
        void Save();
    }
}
