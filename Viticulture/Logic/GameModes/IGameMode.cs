using Viticulture.Logic.State;

namespace Viticulture.Logic.GameModes
{
    public interface IGameMode
    {
        string Name { get; }

        string Description { get; }
        void Initialize(IGameState gameState);
    }
}