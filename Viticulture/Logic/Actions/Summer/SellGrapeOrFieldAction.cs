using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(SellGrapeOrFieldAction))]
    public class SellGrapeOrFieldAction : BonusAction, ISummerAction
    {
        public override string Text => "Sell 1 grape or sell/buy 1 field";
        public override string BonusText => "+1 VP";

        [ImportingConstructor]
        public SellGrapeOrFieldAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.VictoryPoints++;
            return Task.FromResult(true);
        }
    }
}