using System.ComponentModel.Composition;

namespace Viticulture.Logic.Cards.Orders
{
    [InheritedExport]
    public abstract class OrderCard : Card
    {
        public override string Name => string.Empty;

        public override string Text => string.Empty;
    }
}
