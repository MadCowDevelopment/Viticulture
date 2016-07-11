using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions
{
    public class GainLiraAction : PlayerAction, ISummerAction, IWinterAction
    {
        [ImportingConstructor]
        public GainLiraAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool CanExecuteSpecial => true;
        protected override bool IsUnlimited => true;

        public override string Text => "Gain 1 lira";

        public override Task<bool> OnExecute()
        {
            GameState.Money++;
            return Task.FromResult(true);
        }
    }
}