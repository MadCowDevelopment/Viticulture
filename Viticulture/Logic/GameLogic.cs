using System.Collections.Generic;
using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.Actions;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.State;
using Viticulture.Services;
using Viticulture.Utils;

namespace Viticulture.Logic
{
    [Export(typeof(IGameLogic))]
    public class GameLogic : IGameLogic
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IGameState _gameState;
        private readonly IPlayerSelection _playerSelection;
        private readonly IEnumerable<PlayerAction> _actions;

        [ImportingConstructor]
        public GameLogic(IEventAggregator eventAggregator, IGameState gameState, IPlayerSelection playerSelection,
            [ImportMany] IEnumerable<PlayerAction> actions)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _gameState = gameState;
            _playerSelection = playerSelection;
            _actions = actions;
        }

        public void Initialize(IGameMode gameMode)
        {
            _gameState.Reset();
            gameMode.Initialize(_gameState);
        }

        public async void EndSeason()
        {
            if (_gameState.Season == Season.Spring)
            {
                _gameState.AutomaCard?.Discard();
                _gameState.AutomaCard = _gameState.AutomaDeck.Draw();
                _gameState.AutomaCard.BlockedSummerActions.ForEach(p => p.HasBeenUsed = true);
                _gameState.Season++;
            }
            else if (_gameState.Season == Season.Summer)
            {
                var result = await _playerSelection.Select("Fall", "Choose a visitor card", "summer", "winter");
                if (result == Selection.Option1) _gameState.SummerVisitorDeck.DrawToHand();
                else _gameState.WinterVisitorDeck.DrawToHand();

                _gameState.Season++;

                _gameState.AutomaCard?.Discard();
                _gameState.AutomaCard = _gameState.AutomaDeck.Draw();
                _gameState.AutomaCard.BlockedWinterActions.ForEach(p => p.HasBeenUsed = true);
                _gameState.Season++;
            }
            else if (_gameState.Season == Season.Winter)
            {
                EndRound();
            }
        }

        private void EndRound()
        {
            if (CheckGameOver())
            {
                _eventAggregator.PublishOnCurrentThread(new GameOverMessage(_gameState));
                return;
            }

            _actions.ForEach(p => p.Reset());
            _gameState.Season = Season.Spring;
            _gameState.Round++;
            _gameState.Money += _gameState.ResidualMoney;
            _gameState.Pieces.ForEach(p => p.Reset());
        }

        private bool CheckGameOver()
        {
            return _gameState.Round == _gameState.NumberOfRounds;
        }
    }

    public class GameOverMessage
    {
        public IGameState GameState { get; private set; }

        public GameOverMessage(IGameState gameState)
        {
            GameState = gameState;
        }
    }
}