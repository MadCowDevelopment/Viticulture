using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class Irigation : Building
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