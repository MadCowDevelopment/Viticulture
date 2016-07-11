using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class Irigation : Structure
    {
        public Irigation(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Irigation()
        {
        }

        public override int Cost => 3;
        public override string Name => "Irigation";
    }
}