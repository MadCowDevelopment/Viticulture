using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class HarvestExpert : TwoChoicesVisitorCard
    {
        public override string Name => "Harvest Expert";
        public override Season Season => Season.Winter;

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var success = await HarvestField.OnExecute();
            if (!success) return false;
            gameState.VineDeck.DrawToHand();
            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var success = await HarvestField.OnExecute();
            if (!success) return false;
            gameState.Yoke.IsBought = true;
            gameState.Money -= gameState.Yoke.Cost - 1;
            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Money >= gameState.Yoke.Cost - 1 && !gameState.Yoke.IsBought;
        }

        protected override string Option1 => "harvest 1 field and draw 1 vine";
        protected override string Option2 => "harvest 1 field and build a Yoke at 1 lira discount";
    }
}