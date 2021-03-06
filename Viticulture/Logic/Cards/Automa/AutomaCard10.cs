using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Summer;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard10 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard10(PlantVineAction plantVine, SellGrapeOrFieldAction sellGrapeOrField, TrainWorkerAction trainWorker)
        {
            BlockedSummerActions = new List<BonusAction> { plantVine, sellGrapeOrField };
            BlockedWinterActions = new List<BonusAction> { trainWorker };
        }
        public AutomaCard10() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}