using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(TrainWorkerAction))]
    public class TrainWorkerAction : BonusAction, IWinterAction
    {
        public override string Text => "Train 1 worker";

        public override string BonusText => "+1 lira";

        [ImportingConstructor]
        public TrainWorkerAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            GameState.Workers.First(p => !p.IsBought).IsBought = true;
            GameState.Money -= 4;
            return true;
        }

        protected override void OnExecuteBonus()
        {
            GameState.Money++;
        }
    }
}