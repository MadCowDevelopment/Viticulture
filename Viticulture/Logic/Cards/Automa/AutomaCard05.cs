using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard05 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard05(GiveTourAction giveTour, HarvestFieldAction harvestField)
        {
            BlockedSummerActions = new List<BonusAction> { giveTour };
            BlockedWinterActions = new List<BonusAction> { harvestField };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}