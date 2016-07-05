using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic
{
    [Export(typeof(IGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameLogic : IGameLogic, IHandle<GameStateChanged>
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

        public void Handle(GameStateChanged message)
        {
            if (message.PropertyName == _gameState.GetMemberName(p => p.Season))
            {
                HandleSeasonChange();
            }
        }

        private void HandleSeasonChange()
        {
            if (_gameState.Season == Season.Summer)
            {
                if (_gameState.AutomaCard != null) _gameState.AutomaDeck.Discard(_gameState.AutomaCard);
                _gameState.AutomaCard = _gameState.AutomaDeck.Draw();
            }
        }
    }
}