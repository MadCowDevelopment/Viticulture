using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class GovernessCard : TwoChoicesVisitorCard
    {
        public override string Name => "Governess";
        public override Season Season => Season.Winter;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            var worker = gameState.BuyWorker(3);
            if (worker == null) return Task.FromResult(false);
            worker.HasBeenUsed = false;
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine =
                await
                    PlayerSelection.Select("Select wine", "Choose 1 wine to discard",
                        gameState.Wines.Where(p => p.IsBought));
            if (selectedWine == null) return false;
            selectedWine.IsBought = false;
            gameState.VictoryPoints += 2;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 3;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Any(p => p.IsBought);
        }

        protected override string Option1 => "pay 3 lira to train 1 worker that you can use this year";
        protected override string Option2 => "discard 1 wine to gain 2 VP";
    }
}