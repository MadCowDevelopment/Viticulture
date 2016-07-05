using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(SellGrapeOrFieldAction))]
    public class SellGrapeOrFieldAction : BonusAction, ISummerAction
    {
        public override string Text => "Sell 1 grape or sell/buy 1 field";
        public override string BonusText => "+1 VP";
        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public SellGrapeOrFieldAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}