using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.State;
using Viticulture.Services;
using Viticulture.Utils;

namespace Viticulture.Logic
{
    [Export(typeof(IGameLogic))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameLogic : IGameLogic, IHandle<GameStateChanged>
    {
        private readonly IGameState _gameState;
        private readonly IPlayerSelection _playerSelection;

        [ImportingConstructor]
        public GameLogic(IEventAggregator eventAggregator, IGameState gameState, IPlayerSelection playerSelection)
        {
            eventAggregator.Subscribe(this);
            _gameState = gameState;
            _playerSelection = playerSelection;
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

        private async void HandleSeasonChange()
        {
            if (_gameState.Season == Season.Summer)
            {
                if (_gameState.AutomaCard != null) _gameState.AutomaDeck.Discard(_gameState.AutomaCard);
                _gameState.AutomaCard = _gameState.AutomaDeck.Draw();
                _gameState.AutomaCard.BlockedSummerActions.ForEach(p => p.HasBeenUsed = true);
                _gameState.AutomaCard.BlockedWinterActions.ForEach(p => p.HasBeenUsed = true);
            }
            else if (_gameState.Season == Season.Fall)
            {
                var result = await _playerSelection.Select("Fall", "Choose a visitor card", "summer", "winter");
                if (result == Selection.Option1) _gameState.SummerVisitorDeck.DrawToHand();
                else _gameState.WinterVisitorDeck.DrawToHand();
                _gameState.Season = Season.Winter;
            }
        }
    }
}