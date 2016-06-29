using System.ComponentModel.Composition;
using Viticulture.Logic.State;

namespace Viticulture.Logic.GameModes
{
    [InheritedExport(typeof(IGameMode))]
    public abstract class GameMode : IGameMode
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract void Initialize(IGameState gameState);
    }
}