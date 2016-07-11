using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class LargeCellar : Structure
    {
        public LargeCellar(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public LargeCellar()
        {
        }

        public override int Cost => 6;
        public override string Name => "Large cellar";
    }
}