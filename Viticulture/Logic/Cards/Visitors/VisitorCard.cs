using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors
{
    public abstract class VisitorCard : Card
    {
        public abstract Season Season { get; }
    }
}
