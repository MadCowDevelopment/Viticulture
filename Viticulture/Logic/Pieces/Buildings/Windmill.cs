using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class Windmill : Building
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