using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(DrawOrderAction))]
    public class DrawOrderAction : PlayerAction, IWinterAction
    {
        public override string Text => "Draw 1 order";
        public override string BonusText => "+1 order";

        public override void Execute()
        {
        }
    }
}