using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class UncertifiedTeacherCard : VisitorCard
    {
        public override string Description => "Lose 1 VP to gain 1 worker";
        public override string Name => "Uncertified Teacher";
        public override Season Season => Season.Winter;
        public override bool CanPlay(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints && gameState.Workers.Any(p => !p.IsBought);
        }

        protected override Task<bool> OnApply(IGameState gameState)
        {
            var worker = gameState.BuyWorker(0);
            gameState.VictoryPoints--;
            return Task.FromResult(worker != null);
        }
    }
}