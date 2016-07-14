using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard14 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard14(GiveTourAction giveTour, SellGrapeOrFieldAction sellGrapeOrField, DrawOrderAction drawOrder, MakeWineAction makeWine)
        {
            BlockedSummerActions = new List<BonusAction> { giveTour, sellGrapeOrField };
            BlockedWinterActions = new List<BonusAction> { drawOrder, makeWine };
        }
        public AutomaCard14() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}