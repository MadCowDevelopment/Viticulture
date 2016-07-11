using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class Trellis : Structure
    {
        public Trellis(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Trellis()
        {
        }

        public override int Cost => 2;
        public override string Name => "Trellis";
    }
}