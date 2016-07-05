using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(MakeWineAction))]
    public class MakeWineAction : PlayerAction, IWinterAction
    {
        public override string Text => "Make up to 2 wine tokens";
        public override string BonusText => "+1 wine";

        public override void Execute()
        {
        }
    }
}