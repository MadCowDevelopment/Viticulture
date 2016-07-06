using System.ComponentModel.Composition;
using System.Threading.Tasks;
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