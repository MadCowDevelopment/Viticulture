using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(FillOrderAction))]
    public class FillOrderAction : BonusAction, IWinterAction
    {
        public override string Text => "Fill 1 order";
        public override string BonusText => "+1 VP";

        [ImportingConstructor]
        public FillOrderAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            GameState.VictoryPoints++;
        }
    }
}