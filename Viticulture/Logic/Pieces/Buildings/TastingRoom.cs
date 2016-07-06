using Caliburn.Micro;

namespace Viticulture.Logic.Pieces.Buildings
{
    public class TastingRoom : Building
    {
        public TastingRoom(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public override int Cost => 6;
        public override string Name => "Tasting room";
    }
}