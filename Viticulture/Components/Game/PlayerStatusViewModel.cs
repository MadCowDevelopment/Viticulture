using System;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.State;

namespace Viticulture.Components.Game
{
    [Export(typeof(IPlayerStatusViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PlayerStatusViewModel : ViewModel, IPlayerStatusViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public PlayerStatusViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public int Bonus => _gameState.RemainingBonusActions;

        public int Lira => _gameState.Money;

        public int Round => _gameState.Round;

        public int Workers => _gameState.Workers.Count(worker => worker.HasBeenUsed);
    }
}