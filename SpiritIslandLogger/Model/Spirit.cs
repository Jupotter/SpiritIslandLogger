using System;
using System.Collections.Generic;
using System.Text;

namespace SpiritIslandLogger.Model
{
    record Spirit(string Name, Guid id)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
