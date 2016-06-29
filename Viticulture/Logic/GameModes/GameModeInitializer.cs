using Viticulture.Logic.State;

namespace Viticulture.Logic.GameModes
{
    public abstract class GameModeInitializer : IGameModeInitializer
    {
        public abstract void Initialize(IGameState gameState);
    }
}