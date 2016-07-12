using System.ComponentModel.Composition;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Benefits
{
    [InheritedExport]
    public abstract class Benefit : IHasDescription
    {
        public abstract string Name { get; }

        public void Apply(IGameState gameState)
        {
            gameState.RemainingBonusActions++;
            OnApply(gameState);
        }

        public abstract void OnApply(IGameState gameState);
        public string DisplayText => Name;
        public string Description => Name;
    }
}
