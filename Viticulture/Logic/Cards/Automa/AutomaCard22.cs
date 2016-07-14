using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard22 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard22(HarvestFieldAction harvestField, TrainWorkerAction trainWorker)
        {
            BlockedSummerActions = new List<BonusAction> { };
            BlockedWinterActions = new List<BonusAction> { harvestField, trainWorker };
        }
        public AutomaCard22() { }

        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}