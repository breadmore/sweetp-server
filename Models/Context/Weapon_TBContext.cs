using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Weapon_TBContext : DbContext
    {
        public Weapon_TBContext(DbContextOptions<Weapon_TBContext> options)
    : base(options)
        {
        }

        public DbSet<Weapon_TB> weapon_tb { get; set; } = null!;

    }
}
