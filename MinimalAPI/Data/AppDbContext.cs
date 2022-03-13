using Microsoft.EntityFrameworkCore;

namespace MinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { 
        }
        public DbSet<Client> Clients { get; set; }
    
    }
}
