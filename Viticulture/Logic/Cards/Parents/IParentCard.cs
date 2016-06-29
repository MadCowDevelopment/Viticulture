using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Parents
{
    public interface IParentCard : ICard
    {
        void Setup(IGameState gameState);
    }
}