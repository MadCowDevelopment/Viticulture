using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public abstract class GamePiece : PropertyChangedBase
    {
        private readonly IEventAggregator _aggregator;

        protected GamePiece(IEventAggregator aggregator)
        {
            _aggregator = aggregator;
            PropertyChanged += GamePiece_PropertyChanged;
        }

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