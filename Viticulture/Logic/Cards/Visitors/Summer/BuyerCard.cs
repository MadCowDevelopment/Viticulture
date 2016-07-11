using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class BuyerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Buyer";
        public override Season Season => Season.Summer;

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var selection = await PlayerSelection.Select("Select grape color",
                "Choose which 1 value grape you want to put on your crushpad", "Red", "White");
            var grapeColor = selection == Selection.Option1 ? GrapeColor.Red : GrapeColor.White;
            gameState.Grapes.First(p => p.GrapeColor == grapeColor && p.Value == 1).IsBought = true;
            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedGrape =
                await
                    PlayerSelection.Select("Select grape", "Choose 1 grap to discard",
                        gameState.Grapes.Where(p => p.IsBought));
            if (selectedGrape == null) return false;
            selectedGrape.IsBought = false;
            gameState.Money += 2;
            gameState.VictoryPoints++;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 2 && gameState.Grapes.Any(p => !p.IsBought);
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Grapes.Any(p => p.IsBought);
        }

        protected override string Option1 => "pay 2 lira to place a 1 value grape on your crushpad";
        protected override string Option2 => "discard 1 grape to gain 2 lira and 1 VP";
    }
}