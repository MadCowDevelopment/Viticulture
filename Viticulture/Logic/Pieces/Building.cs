using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public abstract class Building : GamePiece
    {
        public Building(IEventAggregator aggregator) : base(aggregator)
        {
        }
    }
}