using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard15 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard15(BuildStructureAction buildStructure, DrawOrderAction drawOrder, PlayWinterVisitorAction playWinterVisitor)
        {
            BlockedSummerActions = new List<BonusAction> { buildStructure };
            BlockedWinterActions = new List<BonusAction> { drawOrder, playWinterVisitor };
        }
        public AutomaCard15() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}