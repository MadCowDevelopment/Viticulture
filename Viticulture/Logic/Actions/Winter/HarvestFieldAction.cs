using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(HarvestFieldAction))]
    public class HarvestFieldAction : BonusAction, IWinterAction
    {
        public override string Text => "Harvest 1 field";
        public override string BonusText => "+1 field";

        [ImportingConstructor]
        public HarvestFieldAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            return Task.FromResult(true);
        }
    }
}