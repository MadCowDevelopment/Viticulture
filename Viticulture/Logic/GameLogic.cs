using System.ComponentModel.Composition;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.State;

namespace Viticulture.Logic
{
    [Export(typeof(IGameLogic))]
    public class GameLogic : IGameLogic
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public GameLogic(IGameState gameState)
        {
            _gameState = gameState;
        }

        public void Initialize(IGameMode gameMode)
        {
            gameMode.Initialize(_gameState);
        }
    }
}