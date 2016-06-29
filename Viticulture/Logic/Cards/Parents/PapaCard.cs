using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Parents.Papas;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(IPapaCard))]
    public abstract class PapaCard : ParentCard, IPapaCard
    {
        [Import]
        private IPlayerSelection PlayerSelection { get; set; }

        public sealed override void Setup(IGameState gameState)
        {
            gameState.Grande.IsBought = true;
            var selection = PlayerSelection.Select("Papa card", "Please select one benefit of your papa card", Option1, Option2);
            OnSetup(gameState, selection.Result);
        }

        protected abstract string Option1 { get; }
        protected abstract string Option2 { get; }

        protected abstract void OnSetup(IGameState gameState, Selection selection);
    }
}