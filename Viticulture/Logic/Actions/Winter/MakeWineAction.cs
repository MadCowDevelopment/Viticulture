using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(MakeWineAction))]
    public class MakeWineAction : BonusAction, IWinterAction
    {
        public override string Text => "Make up to 2 wine tokens";
        public override string BonusText => "+1 wine";

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public MakeWineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}