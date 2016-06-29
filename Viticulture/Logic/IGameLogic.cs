using Viticulture.Logic.GameModes;

namespace Viticulture.Logic
{
    public interface IGameLogic
    {
        void Initialize(IGameMode gameMode);
    }
}