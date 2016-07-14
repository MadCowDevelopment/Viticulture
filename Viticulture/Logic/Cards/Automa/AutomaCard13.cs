using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard13 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard13(DrawVineAction drawVine, PlaySummerVisitorAction playSummerVisitor, DrawOrderAction drawOrder, HarvestFieldAction harvestField)
        {
            BlockedSummerActions = new List<BonusAction> { drawVine, playSummerVisitor };
            BlockedWinterActions = new List<BonusAction> { drawOrder, harvestField };
        }
        public AutomaCard13() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}