using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(HarvestFieldAction))]
    public class HarvestFieldAction : PlayerAction, IWinterAction
    {
        public override string Text => "Harvest 1 field";
        public override string BonusText => "+1 field";

        public override void Execute()
        {
        }
    }
}