using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(FillOrderAction))]
    public class FillOrderAction : PlayerAction, IWinterAction
    {
        public override string Text => "Fill 1 order";
        public override string BonusText => "+1 VP";

        public override void Execute()
        {
        }
    }
}