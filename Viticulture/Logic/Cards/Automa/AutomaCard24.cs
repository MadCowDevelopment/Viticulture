using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard24 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard24(PlantVineAction plantVine, MakeWineAction makeWine, FillOrderAction fillOrder)
        {
            BlockedSummerActions = new List<BonusAction> { plantVine };
            BlockedWinterActions = new List<BonusAction> { makeWine, fillOrder };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}