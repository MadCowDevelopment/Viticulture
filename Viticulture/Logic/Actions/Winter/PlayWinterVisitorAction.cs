using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(PlayWinterVisitorAction))]
    public class PlayWinterVisitorAction : BonusAction, IWinterAction
    {
        public override string Text => "Play winter visitor card";
        public override string BonusText => "+1 visitor";

        [ImportingConstructor]
        public PlayWinterVisitorAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }
    }
}