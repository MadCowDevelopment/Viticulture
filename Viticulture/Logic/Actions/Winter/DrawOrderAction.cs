using System.ComponentModel.Composition;
using System.Threading.Tasks;
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

        public override Task<bool> OnExecute()
        {
            GameState.OrderDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.OrderDeck.DrawToHand();
            return Task.FromResult(true);
        }
    }
}