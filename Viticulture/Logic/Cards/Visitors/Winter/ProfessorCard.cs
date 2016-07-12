using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ProfessorCard : TwoChoicesVisitorCard
    {
        public override string Name => "Professor";
        public override Season Season => Season.Winter;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            var worker = gameState.BuyWorker(2);
            return Task.FromResult(worker != null);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            if (gameState.Workers.Count(p => p.IsBought) >= 6)
            {
                gameState.VictoryPoints++;
            }

            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 2 && gameState.Workers.Any(p => !p.IsBought);
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Workers.Count(p => p.IsBought) >= 6;
        }

        protected override string Option1 => "pay 2 lira to train a worker";
        protected override string Option2 => "gain 2 VP if you have 6 workers";
    }
}