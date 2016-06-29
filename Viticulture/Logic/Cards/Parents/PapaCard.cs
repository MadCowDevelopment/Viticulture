using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(IPapaCard))]
    public abstract class PapaCard : ParentCard, IPapaCard
    {
        public sealed override void Setup(IGameState gameState)
        {
            gameState.Grande = new Grande();
            OnSetup(gameState);
        }

        public abstract void OnSetup(IGameState gameState);
    }
}