using System.ComponentModel.DataAnnotations;

namespace sweetp_server.Models
{
    public class Weapon_Data
    {
        [Key]
        public int weapon_id { get; set; }
        public int weapon_type { get; set; }
        public int weapon_unique { get; set; }
        public int weapon_atk { get; set; }
        public int weapon_hp { get; set; }
        public int weapon_element { get; set; }
        public int weapon_durability { get; set; }
        public int weapon_upgrade { get; set; }
    }
}
