using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ScholarCard : TwoChoicesVisitorCard
    {
        public override string Name => "Scholar";
        public override Season Season => Season.Winter;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            var worker = gameState.BuyWorker(3);
            return Task.FromResult(worker != null);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Money >= 3 && gameState.Workers.Any(p => !p.IsBought);
        }

        protected override string DoBothCost => "1 VP";

        protected override bool CanDoBoth(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints && CanApplyOption1(gameState) &&
                   CanApplyOption2(gameState);
        }

        protected override void ApplyCostforDoingBoth(IGameState gameState)
        {
            gameState.VictoryPoints--;
        }

        protected override string Option1 => "draw 2 orders";
        protected override string Option2 => "pay 3 lira to train a worker";
    }
}