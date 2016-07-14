using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard12 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard12(PlantVineAction plantVine, DrawOrderAction drawOrder, FillOrderAction fillOrder)
        {
            BlockedSummerActions = new List<BonusAction> { plantVine };
            BlockedWinterActions = new List<BonusAction> { drawOrder, fillOrder };
        }
        public AutomaCard12() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}