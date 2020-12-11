using System;
using System.Collections.Generic;

namespace SpiritIslandLogger.Model
{
    class Game
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public IList<GamePlayer> Players { get; init; } = new List<GamePlayer>();

        public DateTimeOffset Date { get; init; }
        public bool Victory { get; init; }
        public Adversary? Adversary { get; init; }
        public int? AdversaryLevel { get; init; }
        public int? ManualScore { get; init; }
        public int? DahanLeft { get; init; }
        public int? BlightCount { get; init; }
        public bool? BlightedIsland { get; init; }
        public int? FearLevel { get; init; }
    }
}
