using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(MakeWineAction))]
    public class MakeWineAction : BonusAction, IWinterAction
    {
        public override string Text => "Make up to 2 wine tokens";
        public override string BonusText => "+1 wine";

        [ImportingConstructor]
        public MakeWineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        protected override void OnExecuteBonus()
        {
            
        }
    }
}