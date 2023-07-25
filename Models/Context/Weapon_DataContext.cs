using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Weapon_DataContext :DbContext
    {
        public Weapon_DataContext(DbContextOptions<Weapon_DataContext> options)
    : base(options)
        {
        }

        public DbSet<Weapon_Data> weapon_data { get; set; } = null!;


    }
}
