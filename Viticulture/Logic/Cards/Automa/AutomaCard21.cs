using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard21 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard21(BuildStructureAction buildStructure, PlayWinterVisitorAction playWinterVisitor, FillOrderAction fillOrder)
        {
            BlockedSummerActions = new List<BonusAction> { buildStructure };
            BlockedWinterActions = new List<BonusAction> { playWinterVisitor, fillOrder };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}