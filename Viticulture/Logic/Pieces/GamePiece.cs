using Caliburn.Micro;

namespace Viticulture.Logic.Pieces
{
    public abstract class GamePiece : PropertyChangedBase
    {
        public bool IsBought { get; set; }
        public bool HasBeenUsed { get; set; }
    }
}