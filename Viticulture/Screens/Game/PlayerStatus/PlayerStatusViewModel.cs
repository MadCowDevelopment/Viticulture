using System.ComponentModel.Composition;
using System.Linq;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.PlayerStatus
{
    [Export(typeof(IPlayerStatusViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayerStatusViewModel : ViewModel, IPlayerStatusViewModel, IHandle<GameStateChanged>, IHandle<GamePieceChanged>
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public PlayerStatusViewModel(
            IEventAggregator eventAggregator,
            IGameState gameState)
        {
            eventAggregator.Subscribe(this);

            _gameState = gameState;
        }

        public int Bonus => _gameState.RemainingBonusActions;
        public int VictoryPoints => _gameState.VictoryPoints;
        public int Residual => _gameState.ResidualMoney;
        public int Grande => _gameState.Grande.HasBeenUsed ? 0 : 1;
        public int Lira => _gameState.Money;
        public int Round => _gameState.Round;

        
        public int Workers
        {
            get
            {
                var workers = _gameState.Workers.Count(worker => worker.IsBought && !worker.HasBeenUsed);
                if (_gameState.NeutralWorker.IsBought && !_gameState.NeutralWorker.HasBeenUsed) workers++;
                return workers;
            }
        }

        public void Handle(GameStateChanged message)
        {
            Refresh();
        }

        public void Handle(GamePieceChanged message)
        {
            Refresh();
        }
    }
}