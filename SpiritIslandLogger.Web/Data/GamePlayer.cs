using System.ComponentModel.DataAnnotations;

namespace SpiritIslandLogger.Web.Data
{
    public class GamePlayer
    {
        public                    int     Id     { get; set; }
        [Required] public virtual Game    Game   { get; set; } = null!;
        [Required] public virtual Player? Player { get; set; } = null!;
        [Required] public virtual Spirit? Spirit { get; set; } = null!;
    }
}
