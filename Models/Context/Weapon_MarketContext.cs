using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Weapon_MarketContext : DbContext
    {
        public Weapon_MarketContext(DbContextOptions<Weapon_MarketContext> options)
    : base(options)
        {
        }

        public DbSet<Weapon_Market> weapon_market { get; set; } = null!;


    }
}
