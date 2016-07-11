using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class MediumCellar : Structure
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