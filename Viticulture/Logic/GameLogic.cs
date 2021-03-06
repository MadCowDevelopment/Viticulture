using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Actions;
using Viticulture.Logic.GameModes;
using Viticulture.Logic.Pieces;
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

        public async void Initialize(IGameMode gameMode)
        {
            _gameState.Reset();
            gameMode.Initialize(_gameState);
            if (_gameState.Cottage.IsBought) await SelectSummerOrWinterVisitor();
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
                await SelectSummerOrWinterVisitor();

                _gameState.Season++;

                foreach (var worker in _gameState.AllWorkers.Where(p => p.PlannedAction != null))
                {
                    await worker.PlannedAction.OnExecute();
                }

                _gameState.AutomaCard?.Discard();
                _gameState.AutomaCard = _gameState.AutomaDeck.Draw();
                _gameState.AutomaCard.BlockedWinterActions.ForEach(p => p.HasBeenUsed = true);
                _gameState.Season++;
            }
            else if (_gameState.Season == Season.Winter)
            {
                if (EndRound())
                {
                    return;
                }

                if (_gameState.Cottage.IsBought) await SelectSummerOrWinterVisitor();
            }
        }

        private async Task SelectSummerOrWinterVisitor()
        {
            var result = await _playerSelection.Select("Fall", "Choose a visitor card", "summer", "winter");
            if (result == Selection.Option1) _gameState.SummerVisitorDeck.DrawToHand();
            else _gameState.WinterVisitorDeck.DrawToHand();
        }

        private bool EndRound()
        {
            if (CheckGameOver())
            {
                _eventAggregator.PublishOnCurrentThread(new GameOverMessage(_gameState));
                return true;
            }

            _actions.ForEach(p => p.Reset());
            _gameState.Season = Season.Spring;
            _gameState.Round++;
            _gameState.Money += _gameState.ResidualMoney;
            _gameState.Pieces.ForEach(p => p.Reset());

            AgeGrapes();
            AgeWines();

            return false;
        }

        public void AgeWines()
        {
            AgeGamePiece(_gameState.RedWines.OfType<GamePiece>().ToList());
            AgeGamePiece(_gameState.WhiteWines.OfType<GamePiece>().ToList());
            AgeGamePiece(_gameState.BlushWines.OfType<GamePiece>().ToList());
            AgeGamePiece(_gameState.SparklingWines.OfType<GamePiece>().ToList());
        }

        public void AgeGrapes()
        {
            AgeGamePiece(_gameState.RedGrapes.OfType<GamePiece>().ToList());
            AgeGamePiece(_gameState.WhiteGrapes.OfType<GamePiece>().ToList());
        }

        private void AgeGamePiece(List<GamePiece> grapes)
        {
            for (var i = grapes.Count - 1; i >= 0; i--)
            {
                if (i == grapes.Count) continue;
                if (!grapes[i].IsBought) continue;
                if (grapes[i + 1].IsBought) continue;

                grapes[i].IsBought = false;
                grapes[i + 1].IsBought = true;
            }
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