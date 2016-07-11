using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard04 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard04(GiveTourAction giveTour, BuildStructureAction buildStructure, SellGrapeOrFieldAction sellGrapeOrField, TrainWorkerAction trainWorker)
        {
            BlockedSummerActions = new List<BonusAction> { giveTour, buildStructure, sellGrapeOrField };
            BlockedWinterActions = new List<BonusAction> { trainWorker };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}