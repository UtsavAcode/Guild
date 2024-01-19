using Guild.Data;
using Guild.Models;
using Guild.Repository.IRepository;

namespace Guild.Repository.Implementation
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        ApplicationDbContext _context;
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Profile model)
        {
            _context.Profiles?.Update(model);
        }
    }

}
