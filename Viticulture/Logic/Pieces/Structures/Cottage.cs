using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class Cottage : Structure
    {
        public Cottage(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Cottage()
        {
        }

        public override int Cost => 4;
        public override string Name => "Cottage";
    }
}