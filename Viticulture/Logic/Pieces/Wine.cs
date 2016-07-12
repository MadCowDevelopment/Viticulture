using System.Collections.Generic;
using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public class Wine : GamePiece
    {
        public static int MaxValue = 9;

        public int Value { get; private set; }
        public WineType Type { get; private set; }

        public Wine(IEventAggregator eventAggregator, int value, WineType type) : base(eventAggregator)
        {
            Value = value;
            Type = type;
        }

        public Wine() { }

        protected override void OnClone(Entity entity)
        {
            base.OnClone(entity);
            var clone = entity as Wine;
            clone.Type = Type;
            clone.Value = Value;
        }

        public override string DisplayText => $"{Type}:{Value}";
        public override string Description => string.Empty;

        protected override void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
            base.OnSetFromClone(entity, references);
            var clone = entity as Wine;
            Type = clone.Type;
            Value = clone.Value;
        }
    }
}