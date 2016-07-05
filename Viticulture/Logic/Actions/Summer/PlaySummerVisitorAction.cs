using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlaySummerVisitorAction))]
    public class PlaySummerVisitorAction : BonusAction, ISummerAction
    {
        public override string Text => "Play summer visitor";
        public override string BonusText => "+1 visitor";

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public PlaySummerVisitorAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}