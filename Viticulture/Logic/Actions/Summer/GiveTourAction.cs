using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(GiveTourAction))]
    public class GiveTourAction : PlayerAction, ISummerAction
    {
        public override string Text => "Give tour to gain 2 lira";
        public override string BonusText => "+1 lira";

        public override void Execute()
        {
        }
    }
}