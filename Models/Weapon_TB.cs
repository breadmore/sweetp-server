using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Weapon_TB
    {
        [Key]
        public int weapon_id { get; set; }
        public int weapon_owner {get; set; }
    }
}
