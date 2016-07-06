using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Vines;

namespace Viticulture.Logic.Pieces
{
    public class Field : GamePiece
    {
        public Field(IEventAggregator aggregator, int value) : base(aggregator)
        {
            Value = value;
            IsBought = true;
            Vines = new List<VineCard>();
        }

        public int Value { get; private set; }

        public bool IsSold => !IsBought;

        public List<VineCard> Vines { get; }

        public int RedVines => Vines.Sum(p => p.RedValue);

        public int WhiteVines => Vines.Sum(p => p.WhiteValue);
    }
}
