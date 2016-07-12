using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class JudgeCard : TwoChoicesVisitorCard
    {
        public override string Name => "Judge";
        public override Season Season => Season.Winter;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine =
                await
                    PlayerSelection.Select("Select wine", "Choose wine to discard",
                        gameState.Wines.Where(p => p.IsBought && p.Value >= 4));
            if (selectedWine == null) return false;

            selectedWine.IsBought = false;
            gameState.VictoryPoints += 3;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Any(p => p.IsBought && p.Value >= 4);
        }

        protected override string Option1 => "draw 2 summer visitors";
        protected override string Option2 => "discard 1 wine of value 4 or more to gain 3 VP";
    }
}