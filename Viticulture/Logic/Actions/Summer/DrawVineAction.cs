using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(DrawVineAction))]
    public class DrawVineAction : BonusAction, ISummerAction
    {
        public override string Text => "Draw a vine card";
        public override string BonusText => "+1 vine";

        [ImportingConstructor]
        public DrawVineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            GameState.VineDeck.DrawToHand();
            return true;
        }

        protected override void OnExecuteBonus()
        {
            GameState.VineDeck.DrawToHand();   
        }
    }
}