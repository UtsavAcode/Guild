using Guild.Data;
using Guild.Models;
using Guild.Repository.IRepository;

namespace Guild.Repository.Implementation
{
    public class RegisterRepository : Repository<Register>, IRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
        public void Add(Register register)
        {
            var worker = _context.Add(register);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
