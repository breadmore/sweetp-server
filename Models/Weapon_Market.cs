using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Weapon_Market
    {
        [Key]
        public int weapon_id { get; set; }
        public int weapon_cost { get; set; }

        public int weapon_owner { get; set; }
    }
}
