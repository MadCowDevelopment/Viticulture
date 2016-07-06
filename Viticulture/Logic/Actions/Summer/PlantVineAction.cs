using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlantVineAction))]
    public class PlantVineAction : BonusAction, ISummerAction
    {
        public override string Text => "Plant 1 vine";
        public override string BonusText => "+1 vine";

        [ImportingConstructor]
        public PlantVineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override Task<bool> OnExecute()
        {
            return Task.FromResult(true);
        }

        protected override void OnExecuteBonus()
        {
        }
    }
}