using Caliburn.Micro;
using Viticulture.Logic.Actions;

namespace Viticulture.Logic.Pieces
{
    public class Worker : GamePiece
    {
        public Worker(IEventAggregator aggregator) : base(aggregator)
        {
        }

        public Worker() { }
        public override string DisplayText => "Worker";
        public PlayerAction PlannedAction { get; set; }
        public PlayerAction UsedAction { get; set; }

        public override void Reset()
        {
            base.Reset();
            PlannedAction = null;
            UsedAction = null;
        }
    }
}