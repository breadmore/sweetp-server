using Microsoft.EntityFrameworkCore;
using sweetp_server.Models;

namespace sweetp_server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player_TB> Player { get; set; }
       
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }

    }
}
