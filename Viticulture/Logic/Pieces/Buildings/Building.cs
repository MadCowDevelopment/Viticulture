using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public abstract class Building : GamePiece
    {
        protected Building(IEventAggregator aggregator) : base(aggregator)
        {
        }

        protected Building() { }

        public abstract int Cost { get; }

        public abstract string Name { get; }
    }
}