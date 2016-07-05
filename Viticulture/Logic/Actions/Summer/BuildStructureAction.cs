using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(BuildStructureAction))]
    public class BuildStructureAction : BonusAction, ISummerAction
    {
        public override string Text => "Build 1 structure";
        public override string BonusText => "+1 lira";

        [ImportingConstructor]
        public BuildStructureAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override bool OnExecute()
        {
            return true;
        }

        protected override void OnExecuteBonus()
        {
            GameState.Money++;
        }
    }
}