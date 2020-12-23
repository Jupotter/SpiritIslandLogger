using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SpiritIslandLogger.Web.Data
{
    public class Adversary
    {
        public int    Id   { get; set; }
        
        public string Name { get; set; } = null!;

        [NotMapped]
        public int[] Difficulty { get; set; } = new int[7];


        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MappedDifficulty
        {
            get => string.Join(';', Difficulty);
            set => Difficulty = value.Split(';', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
    }
}
