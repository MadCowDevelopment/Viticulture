using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(DrawOrderAction))]
    public class DrawOrderAction : BonusAction, IWinterAction
    {
        public override string Text => "Draw 1 order";
        public override string BonusText => "+1 order";

        [ImportingConstructor]
        public DrawOrderAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            GameState.OrderDeck.DrawToHand();
            return true;
        }

        protected override void OnExecuteBonus()
        {
            GameState.OrderDeck.DrawToHand();
        }
    }
}