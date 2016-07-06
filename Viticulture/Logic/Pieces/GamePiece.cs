using System.Collections.Generic;
using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public abstract class GamePiece : Entity
    {
        private readonly IEventAggregator _aggregator;

        protected GamePiece(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            PropertyChanged += GamePiece_PropertyChanged;
        }

        protected GamePiece() { }

        private void GamePiece_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _aggregator.PublishOnCurrentThread(new GamePieceChanged(this));

        }

        public bool IsBought { get; set; }

        public bool HasBeenUsed { get; set; }

        public virtual void Reset()
        {
            HasBeenUsed = false;
        }

        protected override void OnClone(Entity entity)
        {
            base.OnClone(entity);
            var clone = entity as GamePiece;
            clone.HasBeenUsed = HasBeenUsed;
            clone.IsBought = IsBought;
        }

        protected override void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
            base.OnSetFromClone(entity, references);
            var clone = entity as GamePiece;
            HasBeenUsed = clone.HasBeenUsed;
            IsBought = clone.IsBought;
        }
    }

    public class GamePieceChanged
    {
        public GamePiece GamePiece { get; private set; }

        public GamePieceChanged(GamePiece gamePiece)
        {
            GamePiece = gamePiece;
        }
    }
}