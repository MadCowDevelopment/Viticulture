using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard06 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard06(BuildStructureAction buildStructure, DrawOrderAction drawOrder, FillOrderAction fillOrder)
        {
            BlockedSummerActions = new List<BonusAction> { buildStructure };
            BlockedWinterActions = new List<BonusAction> { drawOrder, fillOrder };
        }
        public AutomaCard06() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}