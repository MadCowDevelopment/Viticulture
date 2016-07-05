using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlaySummerVisitorAction))]
    public class PlaySummerVisitorAction : PlayerAction, ISummerAction
    {
        public override string Text => "Play summer visitor";
        public override string BonusText => "+1 visitor";

        public override void Execute()
        {
        }
    }
}