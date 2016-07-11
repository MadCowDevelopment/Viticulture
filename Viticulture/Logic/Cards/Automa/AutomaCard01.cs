using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard01 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard01(DrawVineAction drawVine, GiveTourAction giveTour)
        {
            BlockedSummerActions = new List<BonusAction> { drawVine, giveTour };
            BlockedWinterActions = new List<BonusAction>();
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}