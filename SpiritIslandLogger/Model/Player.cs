using System;
using System.Collections.Generic;
using System.Text;

namespace SpiritIslandLogger.Model
{
    record Player(string Name)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
