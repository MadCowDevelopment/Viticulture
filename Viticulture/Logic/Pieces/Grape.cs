using System.Collections.Generic;
using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public class Grape : GamePiece
    {
        public int Value { get; private set; }
        public GrapeColor GrapeColor { get; private set; }

        public Grape(IEventAggregator eventAggregator, int value, GrapeColor grapeColor) : base(eventAggregator)
        {
            Value = value;
            GrapeColor = grapeColor;
        }

        public Grape() { }

        protected override void OnClone(Entity entity)
        {
            base.OnClone(entity);
            var clone = entity as Grape;
            clone.GrapeColor = GrapeColor;
            clone.Value = Value;
        }

        protected override void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
            base.OnSetFromClone(entity, references);
            var clone = entity as Grape;
            GrapeColor = clone.GrapeColor;
            Value = clone.Value;
        }
    }
}