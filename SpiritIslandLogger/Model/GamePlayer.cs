using System;

namespace SpiritIslandLogger.Model
{
    class GamePlayer
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Player? Player { get; init; }
        public Spirit? Spirit { get; init; }

    }
}
