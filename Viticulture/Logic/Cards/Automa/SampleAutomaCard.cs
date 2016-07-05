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
            BlockedSummerActions = new List<PlayerAction> { giveTourAction, playSummerVisitorAction };
            BlockedWinterActions = new List<PlayerAction> { harvestFieldAction };
        }

        public override List<PlayerAction> BlockedSummerActions { get; }
        public override List<PlayerAction> BlockedWinterActions { get; }
    }
}