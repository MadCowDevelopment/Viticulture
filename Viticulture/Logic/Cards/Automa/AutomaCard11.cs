using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard11 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard11(PlaySummerVisitorAction playSummerVisitor, SellGrapeOrFieldAction sellGrapeOrField, HarvestFieldAction harvestFieldAction)
        {
            BlockedSummerActions = new List<BonusAction> { playSummerVisitor, sellGrapeOrField };
            BlockedWinterActions = new List<BonusAction> { harvestFieldAction };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}