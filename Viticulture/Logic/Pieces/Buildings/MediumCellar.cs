using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class MediumCellar : Building
    {
        public MediumCellar(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public MediumCellar()
        {
        }

        public override int Cost => 4;
        public override string Name => "Medium cellar";
    }
}