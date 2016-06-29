using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Services;

namespace Viticulture.Components.Game
{
    [Export(typeof(IGameViewModel))]
    public class GameViewModel : Screen, IGameViewModel
    {
        private readonly INavigationService _navigationService;

        [ImportingConstructor]
        public GameViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}