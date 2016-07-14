using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard02 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard02(DrawVineAction drawVine, BuildStructureAction buildStructure, PlantVineAction plantVine, MakeWineAction makeWine)
        {
            BlockedSummerActions = new List<BonusAction> { drawVine, buildStructure, plantVine };
            BlockedWinterActions = new List<BonusAction> { makeWine };
        }
        public AutomaCard02() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}