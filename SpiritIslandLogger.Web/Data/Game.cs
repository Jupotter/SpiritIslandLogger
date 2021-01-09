using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SpiritIslandLogger.Web.Data
{
    public class Game
    {
        public int Id { get; set; }

        public IList<GamePlayer>? Players { get; set; } = new List<GamePlayer>();

        public DateTimeOffset Date            { get; set; }
        public bool           Victory         { get; set; }
        public Adversary?     Adversary       { get; set; }
        public int?           AdversaryLevel  { get; set; }
        public int?           ManualScore     { get; set; }
        public int?           DahanLeft       { get; set; }
        public int?           BlightCount     { get; set; }
        public bool?          BlightedIsland  { get; set; }
        public int?           FearLevel       { get; set; }
        public int?           InvaderCardsLeft { get; set; }

        public string Comment { get; set; } = "";

        [NotMapped]
        public int? RealScore
        {
            get
            {
                if (ManualScore.HasValue)return ManualScore ;
                if (Players?.Count > 0 &&
                    DahanLeft.HasValue      &&
                    BlightCount.HasValue    &&
                    BlightedIsland.HasValue &&
                    InvaderCardsLeft.HasValue)
                {
                    var score      = DahanLeft / Players.Count - BlightCount / Players.Count;

                    int difficulty = 0;
                    int deckSize   = 12;
                    if (Adversary != null && AdversaryLevel.HasValue && Adversary.Levels != null)
                    {
                        var level = Adversary.Levels.First(l => l.Level == AdversaryLevel.Value);
                        difficulty = level.Difficulty;
                        deckSize = level.DeckSize;
                    }

                    if (Victory)
                    {
                        score += 5 * difficulty + 10 + 2 * InvaderCardsLeft;
                    }
                    else
                    {
                        score += 2 * difficulty + 2 * (deckSize-InvaderCardsLeft);
                    }

                    return score;
                }

                return null;
            }
        }
    }
}
