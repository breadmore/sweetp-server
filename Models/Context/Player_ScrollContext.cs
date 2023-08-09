using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Player_ScrollContext : DbContext
    {
        public Player_ScrollContext(DbContextOptions<Player_ScrollContext> options)
    : base(options)
        {
        }

        public DbSet<Player_Scroll> player_scroll { get; set; } = null!;

    }
}
