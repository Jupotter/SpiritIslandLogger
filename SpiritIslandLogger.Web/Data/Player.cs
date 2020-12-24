using System.ComponentModel.DataAnnotations;

namespace SpiritIslandLogger.Web.Data
{
    public class Player
    {
        public int    Id   { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
