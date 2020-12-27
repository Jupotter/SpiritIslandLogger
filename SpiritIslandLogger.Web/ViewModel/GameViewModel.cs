using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpiritIslandLogger.Web.Data;

namespace SpiritIslandLogger.Web.ViewModel
{
    public class GameViewModel
    {
        public bool Saving { get; private set; }

        public class GamePlayerVm
        {
            public            bool   NewPlayer     { get; set; }
            [Required] public string NewPlayerName { get; set; } = "";
            public            int    PlayerId      { get; set; }
            [Required] public int    SpiritId      { get; set; }
        }

        [Required] public DateTimeOffset Date { get; set; } = DateTimeOffset.Now.Date;

        private int playerCount;

        [Range(1, 6)]
        public int PlayerCount
        {
            get => this.playerCount;
            set
            {
                this.playerCount = value;
                this.GamePlayers = Enumerable.Range(0, this.playerCount).Select(_ => new GamePlayerVm()).ToList();
            }
        }

        public bool Victory  { get; set; }
        public bool Blighted { get; set; }

        public               int? AdversaryId    { get; set; }
        [Range(0, 6)] public int? AdversaryLevel { get; set; }

        [Range(0, int.MaxValue)] public int? DahanLeft  { get; set; }
        [Range(0, int.MaxValue)] public int? BlightLeft { get; set; }
        [Range(0, int.MaxValue)] public int? CardsLeft  { get; set; }
        [Range(0, int.MaxValue)] public int? Score      { get; set; }

        [Range(1, 4)] public int? FearLevel { get; set; }

        public List<GamePlayerVm> GamePlayers { get; set; } = new();

        private readonly ApplicationDbContext dbContext;

        public IEnumerable<Player>    KnownPlayers { get; set; } = Array.Empty<Player>();
        public IEnumerable<Adversary> Adversaries  { get; set; } = Array.Empty<Adversary>();
        public IEnumerable<Spirit>    Spirits      { get; set; } = Array.Empty<Spirit>();

        public GameViewModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task InitializeAsync()
        {
            this.KnownPlayers = await this.dbContext.Players.ToListAsync();
            this.Adversaries = await this.dbContext.Adversaries.ToListAsync();
            this.Spirits = await this.dbContext.Spirits.ToListAsync();
        }

        public async Task LoadGameAsync(int? gameId)
        {
            if (gameId == null)
            {
                return;
            }

            game = await this.dbContext.Games
                             .Include(g => g.Adversary)
                             .ThenInclude(a => a.Levels)
                             .Include(g => g.Players)
                             .ThenInclude(gp => gp.Player)
                             .Include(g => g.Players)
                             .ThenInclude(gp => gp.Spirit)
                             .FirstOrDefaultAsync(g => g.Id == gameId);

            AdversaryLevel = this.game.AdversaryLevel;
            BlightLeft = this.game.BlightCount;
            Blighted = this.game.BlightedIsland ?? false;
            DahanLeft = this.game.DahanLeft;
            Date = this.game.Date;
            Victory = this.game.Victory;
            FearLevel = this.game.FearLevel;
            Score = this.game.ManualScore;
            CardsLeft = this.game.InvaderCardsLeft;
            AdversaryId = this.game.Adversary?.Id;
            PlayerCount = this.game.Players.Count;

            GamePlayers = this.game.Players.Select(vm => new GamePlayerVm
                                                         {
                                                             PlayerId = vm.Player.Id,
                                                             SpiritId = vm.Spirit.Id
                                                         })
                              .ToList();
        }

        private Game game = new();

        public async Task SaveGameAsync()
        {
            Saving = true;
            try
            {
                this.game.AdversaryLevel = AdversaryLevel;
                this.game.BlightCount = BlightLeft;
                this.game.BlightedIsland = Blighted;
                this.game.DahanLeft = DahanLeft;
                this.game.Date = Date;
                this.game.Victory = Victory;
                this.game.FearLevel = FearLevel;
                this.game.ManualScore = Score;
                this.game.InvaderCardsLeft = CardsLeft;
                this.game.Adversary = AdversaryId.HasValue
                                          ? await this.dbContext.Adversaries.FindAsync(AdversaryId.Value)
                                          : null;

                var gamePlayers = new List<GamePlayer>();
                foreach (var gamePlayerVm in GamePlayers)
                {
                    Player player;
                    if (gamePlayerVm.NewPlayer)
                    {
                        player = new Player { Name = gamePlayerVm.NewPlayerName };
                        await this.dbContext.Players.AddAsync(player);
                    }
                    else
                    {
                        player = await this.dbContext.Players.FindAsync(gamePlayerVm.PlayerId);
                    }

                    var spirit = await this.dbContext.Spirits.FindAsync(gamePlayerVm.SpiritId);
                    gamePlayers.Add(new GamePlayer
                                    {
                                        Player = player,
                                        Spirit = spirit
                                    });
                }

                game.Players = gamePlayers;
                if (this.game.Id == 0)
                    await this.dbContext.Games.AddAsync(game);
                else
                    this.dbContext.Games.Update(game);
                await this.dbContext.SaveChangesAsync();
            }
            finally
            {
                Saving = false;
            }
        }
    }
}
