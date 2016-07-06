using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class LargeCellar : Building
    {
        public LargeCellar(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public override int Cost => 6;
        public override string Name => "Large cellar";
    }
}