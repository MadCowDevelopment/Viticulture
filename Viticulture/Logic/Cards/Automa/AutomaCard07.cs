using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard07 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard07(DrawVineAction drawVine, PlaySummerVisitorAction playSummerVisitor)
        {
            BlockedSummerActions = new List<BonusAction> { drawVine, playSummerVisitor };
            BlockedWinterActions = new List<BonusAction> { };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}