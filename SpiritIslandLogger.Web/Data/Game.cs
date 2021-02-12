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

        public DateTimeOffset Date             { get; set; }
        public bool           Victory          { get; set; }
        public Adversary?     Adversary        { get; set; }
        public int?           AdversaryId      { get; set; }
        public int?           AdversaryLevel   { get; set; }
        public int?           ManualScore      { get; set; }
        public int?           DahanLeft        { get; set; }
        public int?           BlightCount      { get; set; }
        public bool?          BlightedIsland   { get; set; }
        public int?           FearLevel        { get; set; }
        public int?           InvaderCardsLeft { get; set; }

        public int? Score { get; set; }

        public string Comment { get; set; } = "";
    }
}
