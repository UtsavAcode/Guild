using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;

namespace Guild.Repository.Implementation
{
    public class RegisterRepository : Repository<Worker>, IRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Worker worker )
        {
            _context.Workers.Add(worker);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
