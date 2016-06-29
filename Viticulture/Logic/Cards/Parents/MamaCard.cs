using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.Cards.Parents
{
    [InheritedExport(typeof(MamaCard))]
    public abstract class MamaCard : ParentCard
    {
        public sealed override void Setup(IGameState gameState)
        {
            gameState.Workers.Where(p => !p.IsBought).Take(2).ForEach(p => p.IsBought = true);
            OnSetup(gameState);
        }

        protected abstract void OnSetup(IGameState gameState);
    }
}