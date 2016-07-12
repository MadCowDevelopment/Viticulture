using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Logic.Actions.Winter;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class HarvesterCard : TwoChoicesVisitorCard
    {
        public override string Name => "Harvester";
        public override Season Season => Season.Summer;

        [Import]
        public HarvestFieldAction HarvestField { get; set; }

        protected override async Task<bool> ApplyOption1(IGameState gameState)
        {
            if (!(await HarvestTwoFields())) return false;
            gameState.Money += 2;
            return true;
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            if (!(await HarvestTwoFields())) return false;
            gameState.VictoryPoints++;
            return true;
        }

        private async Task<bool> HarvestTwoFields()
        {
            var success = await HarvestField.OnExecute();
            if (!success) return false;

            success = await HarvestField.OnExecute();
            if (!success)
            {
                return (await MetroDialog.ShowMessage("Done or cancel",
                    "Are you done harvesting or do you want to cancel the visitor card",
                    MessageDialogStyle.AffirmativeAndNegative,
                    new MetroDialogSettings { AffirmativeButtonText = "Done", NegativeButtonText = "Cancel" })) ==
                       MessageDialogResult.Affirmative;
            }

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Fields.Any(p => p.Vines.Any());
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Fields.Any(p => p.Vines.Any());
        }

        protected override string Option1 => "harvest up to 2 fields and gain 2 lira";
        protected override string Option2 => "harvest up to 2 fields and gain 1 VP";
    }
}