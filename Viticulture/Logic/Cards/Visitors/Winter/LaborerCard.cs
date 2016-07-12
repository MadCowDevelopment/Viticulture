using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class LaborerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Laborer";
        public override Season Season => Season.Winter;

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        [Import]
        public MakeWineAction MakeWine { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            var success = await HarvestField.OnExecute();
            if (!success) return false;

            if (!HarvestField.CanExecuteSpecial) return true;
            success = await HarvestField.OnExecute();
            if (!success)
            {
                return await MetroDialog.DoneOrCancelVisitor("harvesting");
            }

            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var success = await MakeWine.MakeWine();
            if (!success) return false;

            if (!MakeWine.CanExecuteSpecial) return true;
            success = await MakeWine.MakeWine();
            if (!success)
            {
                return await MetroDialog.DoneOrCancelVisitor("making wine");
            }

            if (!MakeWine.CanExecuteSpecial) return true;
            success = await MakeWine.MakeWine();
            if (!success)
            {
                return await MetroDialog.DoneOrCancelVisitor("making wine");
            }

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return HarvestField.CanExecuteSpecial;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return MakeWine.CanExecuteSpecial;
        }

        protected override bool CanDoBoth(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints && CanApplyOption1(gameState) &&
                   CanApplyOption2(gameState);
        }

        protected override string DoBothCost => "1 VP";

        protected override void ApplyCostforDoingBoth(IGameState gameState)
        {
            gameState.VictoryPoints--;
        }

        protected override string Option1 => "harvest up to 2 fields";
        protected override string Option2 => "make up to 3 wine";
    }
}