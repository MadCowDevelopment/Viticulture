using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class Windmill : Structure
    {
        public Windmill(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Windmill()
        {
        }

        public override int Cost => 5;
        public override string Name => "Windmill";
    }
}