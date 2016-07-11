using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;
using Viticulture.Logic.Actions.Winter;

namespace Viticulture.Logic.Cards.Automa
{
    public class AutomaCard23 : AutomaCard
    {
        [ImportingConstructor]
        public AutomaCard23(DrawOrderAction drawOrder, TrainWorkerAction trainWorker, FillOrderAction fillOrder)
        {
            BlockedSummerActions = new List<BonusAction> { };
            BlockedWinterActions = new List<BonusAction> { drawOrder, trainWorker, fillOrder };
        }
        public override List<BonusAction> BlockedSummerActions { get; }
        public override List<BonusAction> BlockedWinterActions { get; }
    }
}