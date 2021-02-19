using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpiritIslandLogger.Web.Data;

namespace SpiritIslandLogger.Web.Service
{
    public class ScoreService
    {
        private readonly ApplicationDbContext dbContext;

        public ScoreService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int?> GetScore(Game game)
        {
            if (game.ManualScore.HasValue)
                return game.ManualScore;

            var playerCount = game.Players?.Count ?? 0;

            if (playerCount == 0)
            {
                playerCount = await dbContext.GamePlayers.Where(p => p.Game == game).CountAsync();
            }

            var score = game.DahanLeft / playerCount - game.BlightCount / playerCount;

            if (!score.HasValue)
                return null;

            int difficulty = 0;
            int deckSize   = 12;

            var level = await GetAdversaryLevel(game);
            if (level != null)
            {
                difficulty = level.Difficulty;
                deckSize   = level.DeckSize;
            }

            if (game.Victory)
            {
                score += 5 * difficulty + 10 + 2 * game.InvaderCardsLeft;
            }
            else
            {
                score += 2 * difficulty + 2 * (deckSize - game.InvaderCardsLeft);
            }

            return score;
        }

#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        private Task<AdversaryLevel?> GetAdversaryLevel(Game game)
        {
            if (!game.AdversaryLevel.HasValue || !game.AdversaryId.HasValue)
                return Task.FromResult<AdversaryLevel?>(null);

            if (game.Adversary?.Levels != null && game.AdversaryLevel.HasValue)
            {
                var level = game.Adversary.Levels.Single(l => l.Level == game.AdversaryLevel.Value);
                return Task.FromResult(level);
            }

            return dbContext.AdversaryLevels.FirstAsync(l =>
                l.AdversaryId == game.AdversaryId && l.Level == game.AdversaryLevel);
        }
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }
}
