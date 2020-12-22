namespace SpiritIslandLogger.Web.Data
{
    public class GamePlayer
    {
        public int     Id     { get; set; }
        public Player? Player { get; set; }
        public Spirit? Spirit { get; set; }
    }
}
