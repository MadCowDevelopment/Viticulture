using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class PromoterCard : TwoChoicesVisitorCard
    {
        public override string Name => "Promoter";
        public override Season Season => Season.Winter;
        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var selectedGrape =
                await
                    PlayerSelection.Select("Select grape", "Choose a grape to discard",
                        gameState.Grapes.Where(p => p.IsBought));
            if (selectedGrape == null) return false;
            selectedGrape.IsBought = false;
            gameState.VictoryPoints++;
            gameState.ResidualMoney++;
            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine =
                await
                    PlayerSelection.Select("Select grape", "Choose a grape to discard",
                        gameState.Wines.Where(p => p.IsBought));
            if (selectedWine == null) return false;
            selectedWine.IsBought = false;
            gameState.VictoryPoints++;
            gameState.ResidualMoney++;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Grapes.Any(p => p.IsBought);
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Any(p => p.IsBought);
        }

        protected override string Option1 => "discard 1 grape to gain 1 VP and 1 residual";
        protected override string Option2 => "discard 1 wine to gain 1 VP and 1 residual";
    }
}