using System.ComponentModel.DataAnnotations;

namespace SpiritIslandLogger.Web.Data
{
    public class GamePlayer
    {
        public            int    Id     { get; set; }
        [Required] public Player Player { get; set; } = null!;

        [Required] public Spirit Spirit { get; set; } = null!;
    }
}
