using Guild.Models;

namespace Guild.Repository.IRepository
{
    public interface IProfileRepository: IRepository<Profile>
    {

        void Update(Profile model);
        void Save();
    }
}
