using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(DrawVineAction))]
    public class DrawVineAction : PlayerAction, ISummerAction
    {
        public override string Text => "Draw a vine card";
        public override string BonusText => "+1 vine";

        public override void Execute()
        {
        }
    }
}