using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(TrainWorkerAction))]
    public class TrainWorkerAction : PlayerAction, IWinterAction
    {
        public override string Text => "Train 1 worker";
        public override string BonusText => "+1 lira";

        public override void Execute()
        {
        }
    }
}