using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions
{
    public class GainLiraAction : PlayerAction, ISummerAction, IWinterAction
    {
        protected override bool IsUnlimited => true;

        public override string Text => "Gain 1 lira";
        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        [ImportingConstructor]
        public GainLiraAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}