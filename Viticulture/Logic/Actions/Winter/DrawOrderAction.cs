using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(DrawOrderAction))]
    public class DrawOrderAction : BonusAction, IWinterAction
    {
        public override string Text => "Draw 1 order";
        public override string BonusText => "+1 order";

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public DrawOrderAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}