using System.ComponentModel.Composition;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.State;

namespace Viticulture.Logic
{
    [Export(typeof(IGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
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
            _gameState.Reset();
            gameMode.Initialize(_gameState);
        }
    }
}