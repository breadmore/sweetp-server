using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Player_TBContext : DbContext
    {
        public Player_TBContext(DbContextOptions<Player_TBContext> options)
            : base(options)
        {
        }

        public DbSet<Player_TB> player_tb { get; set; } = null!;

    }
}
