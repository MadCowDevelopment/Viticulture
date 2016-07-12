using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class MasterVintnerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Master Vintner";
        public override Season Season => Season.Winter;

        [Import]
        public FillOrderAction FillOrder { get; set; }

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            if (!gameState.MediumCellar.IsBought)
            {
                gameState.MediumCellar.IsBought = true;
                gameState.Money -= gameState.MediumCellar.Cost - 2;
            }
            else
            {
                gameState.LargeCellar.IsBought = true;
                gameState.Money -= gameState.LargeCellar.Cost - 2;
            }

            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine = await PlayerSelection.Select("Select wine", "Choose 1 wine to age", gameState.Wines);
            if (selectedWine == null) return false;

            var nextLevelWine =
                gameState.Wines.FirstOrDefault(p => p.Value == selectedWine.Value + 1 && p.Type == selectedWine.Type);
            if (nextLevelWine == null || nextLevelWine.IsBought)
            {
                return false;
            }

            selectedWine.IsBought = false;
            nextLevelWine.IsBought = true;

            return await FillOrder.OnExecute();
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return (!gameState.MediumCellar.IsBought && gameState.Money >= gameState.MediumCellar.Cost - 2) ||
                   (!gameState.LargeCellar.IsBought && gameState.Money >= gameState.LargeCellar.Cost - 2);
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Any() && gameState.Hand.Orders.Any();
        }

        protected override string Option1 => "upgrade your cellar to the next level at a 2 lira discount";
        protected override string Option2 => "age 1 wine and fill 1 order";
    }
}