using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(TrainWorkerAction))]
    public class TrainWorkerAction : BonusAction, IWinterAction
    {
        public override string Text => "Train 1 worker";
        public override string BonusText => "+1 lira";

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public TrainWorkerAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}