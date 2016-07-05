using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions
{
    public class GainLiraAction : PlayerAction, ISummerAction, IWinterAction
    {
        protected override bool IsUnlimited => true;

        public override string Text => "Gain 1 lira";
        public override bool OnExecute()
        {
            return true;
        }

        [ImportingConstructor]
        public GainLiraAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}