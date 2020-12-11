using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiritIslandLogger.Model
{
    record Adversary(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public IList<int> Difficulty { get; init; } = new List<int>();
    }
}
