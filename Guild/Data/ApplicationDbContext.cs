using Guild.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Guild.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            
        }

        public DbSet<Worker>Workers {  get; set; }
    }
}
