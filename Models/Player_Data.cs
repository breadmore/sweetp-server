using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Player_Data
    {
        [Key]
        public int player_id { get; set; }
        public int player_gold { get; set; }
        public int player_potion { get; set; }

    }
}
