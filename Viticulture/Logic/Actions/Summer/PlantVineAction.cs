using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlantVineAction))]
    public class PlantVineAction : PlayerAction, ISummerAction
    {
        public override string Text => "Plant 1 vine";
        public override string BonusText => "+1 vine";
        public override void Execute()
        {
        }
    }
}