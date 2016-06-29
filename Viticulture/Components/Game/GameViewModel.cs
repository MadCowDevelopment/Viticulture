using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Components.Game
{
    [Export(typeof(IGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameViewModel : Screen, IGameViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public GameViewModel(INavigationService navigationService, IGameState gameState)
        {
            _navigationService = navigationService;
            _gameState = gameState;
        }
    }
}