using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(DrawVineAction))]
    public class DrawVineAction : BonusAction, ISummerAction
    {
        public override string Text => "Draw a vine card";
        public override bool CanExecuteSpecial => GameState.VineDeck.CanDraw(1);
        public override string BonusText => "+1 vine";

        [ImportingConstructor]
        public DrawVineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            GameState.VineDeck.DrawToHand();
            return Task.FromResult(true);
        }

        public override Task<bool> OnExecuteBonus()
        {
            GameState.VineDeck.DrawToHand();
            return Task.FromResult(true);
        }
    }
}