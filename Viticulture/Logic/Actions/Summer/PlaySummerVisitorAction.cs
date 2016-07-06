using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlaySummerVisitorAction))]
    public class PlaySummerVisitorAction : BonusAction, ISummerAction
    {
        public override string Text => "Play summer visitor";
        public override string BonusText => "+1 visitor";

        [ImportingConstructor]
        public PlaySummerVisitorAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            return Task.FromResult(true);
        }
    }
}