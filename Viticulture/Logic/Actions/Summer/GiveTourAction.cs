using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(GiveTourAction))]
    public class GiveTourAction : BonusAction, ISummerAction
    {
        public override string Text => "Give tour to gain 2 lira";
        public override bool CanExecuteSpecial => true;
        public override string BonusText => "+1 lira";

        [ImportingConstructor]
        public GiveTourAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            GameState.Money += 2;
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.Money++;
            return Task.FromResult(true);
        }
    }
}