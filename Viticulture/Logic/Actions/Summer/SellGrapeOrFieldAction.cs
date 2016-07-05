using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(SellGrapeOrFieldAction))]
    public class SellGrapeOrFieldAction : PlayerAction, ISummerAction
    {
        public override string Text => "Sell 1 grape or sell/buy 1 field";
        public override string BonusText => "+1 VP";
        public override void Execute()
        {
        }
    }
}