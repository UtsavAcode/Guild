using Guild.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Guild.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions options) : base(options) { }

        public DbSet<worker> Workers { get; set; }
    }

    
}
