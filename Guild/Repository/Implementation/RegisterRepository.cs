using Guild.Data;
using Guild.Models;
using Guild.Models.Domain;
using Guild.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Guild.Repository.Implementation
{
    public class RegisterRepository : Repository<Worker>, IRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public RegisterRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

     

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Worker obj)
        {
            _context.Workers.Update(obj);
        }
    }
}
