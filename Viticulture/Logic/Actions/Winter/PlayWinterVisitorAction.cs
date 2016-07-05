using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(PlayWinterVisitorAction))]
    public class PlayWinterVisitorAction : PlayerAction, IWinterAction
    {
        public override string Text => "Play winter visitor card";
        public override string BonusText => "+1 visitor";

        public override void Execute()
        {
        }
    }
}