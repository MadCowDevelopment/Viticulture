using System.ComponentModel.Composition;

namespace Viticulture.Logic.Cards.Vines
{
    [InheritedExport(typeof(VineCard))]
    public abstract class VineCard : Card
    {
        public override string Text => string.Empty;

        public abstract bool RequiresIrigation { get; }

        public abstract bool RequiresTODO { get; }

        public abstract int RedValue { get; }

        public abstract int WhiteValue { get; }
    }
}
