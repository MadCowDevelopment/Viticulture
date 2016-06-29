using System.ComponentModel.Composition;
using Viticulture.Logic.State;

namespace Viticulture.Logic.GameModes
{
    [InheritedExport(typeof(IGameMode))]
    public abstract class GameMode : IGameMode
    {
        protected GameMode(IGameModeInitializer initializer)
        {
            Initializer = initializer;
        }

        public abstract string Name { get; }

        public abstract string Description { get; }

        public void Initialize(IGameState gameState)
        {
            Initializer.Initialize(gameState);
        }

        private IGameModeInitializer Initializer { get; }
    }
}