using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Player_Scroll
    {
        [Key]
        public int player_id { get; set; }
        public int normal { get; set; }
        public int unique { get; set; }
        public int legendary { get; set; }
    }
}
