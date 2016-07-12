using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class TasterCard : VisitorCard
    {
        public override string Description => "Discard 1 wine to gain 4 lira. If it is the most valuable wine gain 2 VP"
            ;

        public override string Name => "Taster";
        public override Season Season => Season.Winter;

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Wines.Any(p => p.IsBought);
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var selectedWine =
                await
                    PlayerSelection.Select("Select wine", "Choose 1 wine to discard",
                        gameState.Wines.Where(p => p.IsBought));
            if (selectedWine == null) return false;
            selectedWine.IsBought = false;
            gameState.Money += 4;
            if (gameState.Wines.All(p => p.IsBought && p.Value < selectedWine.Value)) gameState.VictoryPoints += 2;
            return true;
        }
    }
}