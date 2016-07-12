using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ReaperCard : VisitorCard
    {
        public override string Description => "Harvest up to 3 fields. If you harvest 3 fields gain 2 VP.";
        public override string Name => "Reaper";
        public override Season Season => Season.Winter;

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return HarvestField.CanExecuteSpecial;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var success = await HarvestField.OnExecute();
            if (!success) return false;

            if (!HarvestField.CanExecuteSpecial) return true;
            success = await HarvestField.OnExecute();
            if (!success)
            {
                return await MetroDialog.DoneOrCancelVisitor("harvesting");
            }

            if (!HarvestField.CanExecuteSpecial) return true;
            success = await HarvestField.OnExecute();
            if (!success)
            {
                return await MetroDialog.DoneOrCancelVisitor("harvesting");
            }

            gameState.VictoryPoints += 2;

            return true;
        }
    }
}