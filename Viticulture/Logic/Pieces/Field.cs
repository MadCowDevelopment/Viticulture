using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Cards.Vines;

namespace Viticulture.Logic.Pieces
{
    public sealed class Field : GamePiece
    {
        private List<VineCard> _vines;

        public Field(IEventAggregator aggregator, int value) : base(aggregator)
        {
            Value = value;
            IsBought = true;
            _vines = new List<VineCard>();
        }

        public Field() { }

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

        protected override void OnClone(Entity entity)
        {
            base.OnClone(entity);
            var clone = entity as Field;
            clone._vines = _vines.Select(v => v.Clone()).OfType<VineCard>().ToList();
        }

        public override string DisplayText => Value.ToString();

        public override string Description => String.Empty;

        protected override void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
            base.OnSetFromClone(entity, references);
            var clone = entity as Field;
            _vines = new List<VineCard>();
            foreach (var vineCard in clone.Vines)
            {
                _vines.Add(references.OfType<VineCard>().First(p => p.Id == vineCard.Id));
            }
        }
    }
}
