using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors
{
    [InheritedExport(typeof(VisitorCard))]
    public abstract class VisitorCard : Card
    {
        [Import]
        public IMetroDialog MetroDialog { get; set; }

        [Import]
        public IMefContainer MefContainer { get; set; }

        [Import]
        public IPlayerSelection PlayerSelection { get; set; }

        public abstract Season Season { get; }
        public abstract bool CanPlay(IGameState gameState);

        public Task<bool> Apply(IGameState gameState)
        {
            return OnApply(gameState);
        }

        protected abstract Task<bool> OnApply(IGameState gameState);
    }
}
