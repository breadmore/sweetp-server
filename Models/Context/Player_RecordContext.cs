using Microsoft.EntityFrameworkCore;

namespace sweetp_server.Models.Context
{
    public class Player_RecordContext : DbContext
    {

        public Player_RecordContext(DbContextOptions<Player_RecordContext> options) : base(options) 
        { 
        }

        public DbSet<Player_Record> player_record { get; set; } = null!;

    }
}
