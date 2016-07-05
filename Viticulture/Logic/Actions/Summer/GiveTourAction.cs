using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(GiveTourAction))]
    public class GiveTourAction : BonusAction, ISummerAction
    {
        public override string Text => "Give tour to gain 2 lira";
        public override string BonusText => "+1 lira";

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public GiveTourAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}