using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard16 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard16(HarvestFieldAction harvestField, MakeWineAction makeWine)
        {
            BlockedSummerActions = new List<BonusAction> { };
            BlockedWinterActions = new List<BonusAction> { harvestField, makeWine };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}