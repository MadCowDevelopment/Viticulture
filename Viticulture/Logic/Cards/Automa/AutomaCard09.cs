using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard09 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard09(BuildStructureAction buildStructure, SellGrapeOrFieldAction sellGrapeOrField, PlaySummerVisitorAction playSummerVisitor, PlayWinterVisitorAction playWinterVisitor)
        {
            BlockedSummerActions = new List<BonusAction> { buildStructure, sellGrapeOrField, playSummerVisitor };
            BlockedWinterActions = new List<BonusAction> { playWinterVisitor };
        }
        public AutomaCard09() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}