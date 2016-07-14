using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(PapaCard))]
    public abstract class PapaCard : ParentCard
    {
        [Import]
        private IPlayerSelection PlayerSelection { get; set; }

        public sealed override async Task Setup(IGameState gameState)
        {
            gameState.Grande.IsBought = true;
            var selection =
                await
                    PlayerSelection.Select($"Papa {Name}",
                        $"Papa {Name} gives you {StartingMoney} lira, a Grande and one of these:", Option1, Option2);
            gameState.Money += StartingMoney;
            OnSetup(gameState, selection);
        }

        protected abstract string Option1 { get; }
        protected abstract string Option2 { get; }

        protected abstract int StartingMoney { get; }

        protected abstract void OnSetup(IGameState gameState, Selection selection);
    }
}