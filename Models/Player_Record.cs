using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Player_Record
    {
        [Key]
        public int player_id { get; set; }
        public int player_score { get; set; }
    }
}
