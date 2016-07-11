using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class WineCriticCard : TwoChoicesVisitorCard
    {
        public override string Name => "Wine Critic";
        public override Season Season => Season.Summer;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine = await PlayerSelection.Select("Select wine", "Select wine to discard",
                gameState.Wines.Where(p => p.Value >= 7 && p.IsBought));
            if (selectedWine == null) return false;
            selectedWine.IsBought = false;
            gameState.VictoryPoints += 4;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Any(p => p.Value >= 7 && p.IsBought);
        }

        protected override string Option1 => "draw 2 winter visitors";

        protected override string Option2 => "discard 1 wine of value 7+ to gain 4 VP";
    }
}