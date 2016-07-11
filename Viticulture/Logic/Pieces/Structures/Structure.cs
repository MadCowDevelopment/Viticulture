using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public abstract class Structure : GamePiece
    {
        protected Structure(IEventAggregator aggregator) : base(aggregator)
        {
        }

        protected Structure() { }

        public abstract int Cost { get; }

        public abstract string Name { get; }

        public override string DisplayText => Name;
    }
}