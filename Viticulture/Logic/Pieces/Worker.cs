using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public class Worker : GamePiece
    {
        public Worker(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Worker() { }
        public override string DisplayText => "Worker";
        public override string Description { get; }
    }
}