using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class Yoke : Structure
    {
        public Yoke(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Yoke()
        {
        }

        public override int Cost => 2;
        public override string Name => "Yoke";
    }
}