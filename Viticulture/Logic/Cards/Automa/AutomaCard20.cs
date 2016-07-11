using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard20 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard20(GiveTourAction giveTour, SellGrapeOrFieldAction sellGrapeOrField, PlayWinterVisitorAction playWinterVisitor)
        {
            BlockedSummerActions = new List<BonusAction> { giveTour, sellGrapeOrField };
            BlockedWinterActions = new List<BonusAction> { playWinterVisitor };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}