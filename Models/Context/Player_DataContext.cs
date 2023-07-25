using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Player_DataContext : DbContext
    {
   
        public Player_DataContext(DbContextOptions<Player_DataContext> options) : base(options) 
        {
        }

        public DbSet<Player_Data> player_data { get; set; } = null!;

    }
}
