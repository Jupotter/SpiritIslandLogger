using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpiritIslandLogger.Web.Data;

namespace SpiritIslandLogger.Web.Service
{
    public class StatsService
    {
        public record DifficultyStats(int     Difficulty,
                                      int     AdversaryId,
                                      int     AdversaryLevel,
                                      int     Count,
                                      int     WinCount,
                                      decimal MeanScore);

        public record SpiritStats(int    SpiritId,
                                  int    GameCount,
                                  int    WinCount);

        private readonly ApplicationDbContext dbContext;

        public StatsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<DifficultyStats> GetDifficultyStats()
        {
            var queryable = from game in dbContext.Games.Where(g => g.AdversaryId.HasValue)
                            join adversaryLevel in dbContext.AdversaryLevels
                                on new
                                   {
                                       game.AdversaryId,
                                       Level = game.AdversaryLevel
                                   }
                                equals new
                                       {
                                           AdversaryId =
                                               (int?)adversaryLevel.AdversaryId,
                                           Level = (int?)adversaryLevel.Level
                                       }
                                into gamesGj
                            from adversaryLevel in gamesGj.DefaultIfEmpty()
                            group game by new
                                          {
                                              adversaryLevel.Difficulty,
                                              game.AdversaryId,
                                              game.AdversaryLevel
                                          }
                            into grouping
                            select new
                                   {
                                       grouping.Key.Difficulty,
                                       grouping.Key.AdversaryId,
                                       grouping.Key.AdversaryLevel,
                                       Count     = grouping.Count(),
                                       WinCount  = grouping.Count(g => g.Victory),
                                       MeanScore = grouping.Average(g => g.Score)
                                   };

            return queryable.Select(g => new DifficultyStats(g.Difficulty,
                g.AdversaryId.Value,
                g.AdversaryLevel ?? 0,
                g.Count,
                g.WinCount,
                (decimal?)g.MeanScore ?? 0));
        }

        public IQueryable<SpiritStats> GetSpiritStats()
        {
            var query = dbContext.Spirits
                                 .Join(dbContext.GamePlayers,
                                      spirit => spirit.Id,
                                      gamePlayer => gamePlayer.SpiritId,
                                      (spirit, gamePlayer) => new
                                                              {
                                                                  spirit,
                                                                  gamePlayer
                                                              })
                                 .Join(dbContext.Games,
                                      t => t.gamePlayer.GameId,
                                      g => g.Id,
                                      (t, game) => new
                                                   {
                                                       t.spirit,
                                                       game
                                                   })
                                 .GroupBy(@t => @t.spirit.Id)
                                 .Select(grouping => new SpiritStats(
                                      grouping.Key,
                                      grouping.Count(),
                                      grouping.Count(g => g.game.Victory)));
            return query;
        }
    }
}
