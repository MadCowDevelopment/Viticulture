using Viticulture.Logic.State;

namespace Viticulture.Logic.GameModes
{
    public interface IGameModeInitializer
    {
        void Initialize(IGameState gameState);
    }
}