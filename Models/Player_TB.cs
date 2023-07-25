using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Player_TB
    {
        [Key]
        public int player_id { get; set; }

        public string? player_address { get; set; }
    }
}