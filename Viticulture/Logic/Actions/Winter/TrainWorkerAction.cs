using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(TrainWorkerAction))]
    public class TrainWorkerAction : BonusAction, IWinterAction
    {
        public override string Text => "Train 1 worker";
        public override bool CanExecuteSpecial => GameState.Money >= 4;

        public override string BonusText => "+1 lira";

        [ImportingConstructor]
        public TrainWorkerAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            GameState.Workers.First(p => !p.IsBought).IsBought = true;
            GameState.Money -= 4;
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.Money++;
            return Task.FromResult(true);
        }
    }
}