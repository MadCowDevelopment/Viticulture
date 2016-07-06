using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public class Field : GamePiece
    {
        public int Value { get; private set; }

        public Field(IEventAggregator aggregator, int value) : base(aggregator)
        {
            Value = value;
            IsBought = true;
        }
    }
}
