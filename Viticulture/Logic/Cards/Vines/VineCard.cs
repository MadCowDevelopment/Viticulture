using System.ComponentModel.Composition;

namespace Viticulture.Logic.Cards.Vines
{
    [InheritedExport(typeof(VineCard))]
    public abstract class VineCard : Card
    {
        public override string Description => string.Empty;

        public abstract bool RequiresIrigation { get; }

        public abstract bool RequiresTrellis { get; }

        public abstract int RedValue { get; }

        public abstract int WhiteValue { get; }

        public override string DisplayText => $"{Name} {RedValue}/{WhiteValue}";
    }
}
