namespace SpiritIslandLogger.Web.Data
{
    public class Adversary
    {
        public int        Id         { get; set; }
        public string?    Name       { get; set; }
        
        public int Level0Difficulty { get; set; }
        public int Level1Difficulty { get; set; }
        public int Level2Difficulty { get; set; }
        public int Level3Difficulty { get; set; }
        public int Level4Difficulty { get; set; }
        public int Level5Difficulty { get; set; }
        public int Level6Difficulty { get; set; }
    }
}
