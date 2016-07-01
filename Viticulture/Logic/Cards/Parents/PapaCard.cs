using System.ComponentModel.Composition;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(PapaCard))]
    public abstract class PapaCard : ParentCard
    {
        [Import]
        private IPlayerSelection PlayerSelection { get; set; }

        public sealed override async void Setup(IGameState gameState)
        {
            gameState.Grande.IsBought = true;
            var selection = await PlayerSelection.Select("Papa card", "Please select one benefit of your papa card", Option1, Option2);
            OnSetup(gameState, selection);
        }

        protected abstract string Option1 { get; }
        protected abstract string Option2 { get; }

        protected abstract void OnSetup(IGameState gameState, Selection selection);
    }
}