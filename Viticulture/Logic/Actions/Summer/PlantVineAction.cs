using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlantVineAction))]
    public class PlantVineAction : BonusAction, ISummerAction
    {
        public override string Text => "Plant 1 vine";
        public override string BonusText => "+1 vine";
        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            
        }

        [ImportingConstructor]
        public PlantVineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }
    }
}