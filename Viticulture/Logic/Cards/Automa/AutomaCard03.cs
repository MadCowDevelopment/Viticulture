using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard03 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard03(DrawVineAction drawVine, PlaySummerVisitorAction playSummerVisitor, PlayWinterVisitorAction playWinterVisitor)
        {
            BlockedSummerActions = new List<BonusAction> { drawVine, playSummerVisitor };
            BlockedWinterActions = new List<BonusAction> { playWinterVisitor };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}