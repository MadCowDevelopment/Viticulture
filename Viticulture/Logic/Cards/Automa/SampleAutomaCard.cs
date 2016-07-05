using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class SampleAutomaCard : AutomaCard
    {
        [ImportingConstructor]
        public SampleAutomaCard(GiveTourAction giveTourAction, PlaySummerVisitorAction playSummerVisitorAction, HarvestFieldAction harvestFieldAction)
        {
            BlockedSummerActions = new List<BonusAction> { giveTourAction, playSummerVisitorAction };
            BlockedWinterActions = new List<BonusAction> { harvestFieldAction };
        }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}