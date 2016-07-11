using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Structures
{
    public class TastingRoom : Structure
    {
        public TastingRoom(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public TastingRoom()
        {
        }

        public override int Cost => 6;
        public override string Name => "Tasting room";
    }
}