using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Vines;

namespace Viticulture.Logic.Pieces
{
    public class Field : GamePiece
    {
        private readonly List<VineCard> _vines;

        public Field(IEventAggregator aggregator, int value) : base(aggregator)
        {
            Value = value;
            IsBought = true;
            _vines = new List<VineCard>();
        }

        public int Value { get; private set; }

        public bool IsSold => !IsBought;

        public IEnumerable<VineCard> Vines => _vines;

        public int RedVines => Vines.Sum(p => p.RedValue);

        public int WhiteVines => Vines.Sum(p => p.WhiteValue);

        public void PlantVine(VineCard vine)
        {
            _vines.Add(vine);
        }

        public void UprootVine(VineCard vine)
        {
            _vines.Remove(vine);
        }
    }
}
