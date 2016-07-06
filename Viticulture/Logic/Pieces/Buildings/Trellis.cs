using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class Trellis : Building
    {
        public Trellis(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public override int Cost => 2;
        public override string Name => "Trellis";
    }
}