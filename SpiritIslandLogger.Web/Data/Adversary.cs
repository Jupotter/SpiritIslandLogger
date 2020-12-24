using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpiritIslandLogger.Web.Data
{
    public class Adversary
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual IList<AdversaryLevel>? Levels { get; set; } = null;
    }

    public class AdversaryLevel
    {
        public int Id { get; set; }

        [Required] public Adversary Adversary { get; set; } = null!;

        [Required] public int Level { get; set; }

        [Range(0, 11)] public int Difficulty { get; set; }

        [Range(1, int.MaxValue)] public int DeckSize { get; set; } = 12;
    }
}
