using System.ComponentModel.Composition;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(BuildStructureAction))]
    public class BuildStructureAction : PlayerAction, ISummerAction
    {
        public override string Text => "Build 1 structure";
        public override string BonusText => "+1 lira";
        public override void Execute()
        {
        }
    }
}