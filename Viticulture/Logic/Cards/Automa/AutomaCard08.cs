using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard08 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard08(GiveTourAction giveTour, PlantVineAction plantVine, MakeWineAction makeWine)
        {
            BlockedSummerActions = new List<BonusAction> { giveTour, plantVine };
            BlockedWinterActions = new List<BonusAction> { makeWine };
        }
        public AutomaCard08() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}