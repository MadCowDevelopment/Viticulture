using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Actions;

namespace Viticulture.Logic.Cards.Automa
{
    [InheritedExport(typeof(AutomaCard))]
    public abstract class AutomaCard : Card
    {
        public override string Name => string.Empty;
        public override string Description => string.Empty;

        public abstract List<BonusAction> BlockedSummerActions { get; }

        public abstract List<BonusAction> BlockedWinterActions { get; }
    }
}
