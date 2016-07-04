using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.GameModes;
using Viticulture.Screens.Game;
using Viticulture.Screens.MainMenu;
using Viticulture.Services;

namespace Viticulture.Screens.GameModeSelection
{
    [Export(typeof(IGameModeSelectionViewModel))]
    public class GameModeSelectionViewModel : ViewModel, IGameModeSelectionViewModel
    {
        private readonly INavigationService _navigationService;

        [ImportingConstructor]
        public GameModeSelectionViewModel(
            INavigationService navigationService,
            [ImportMany] IEnumerable<IGameMode> gameModes)
        {
            _navigationService = navigationService;

            GameModes = gameModes;
            SelectedGameMode = GameModes.FirstOrDefault();
        }

        public IGameMode SelectedGameMode { get; set; }

        public IEnumerable<IGameMode> GameModes { get; }

        public void GoBack()
        {
            _navigationService.NavigateTo<IMainMenuViewModel>();
        }

        public void StartGame()
        {
            _navigationService.NavigateTo<IGameViewModel, IGameMode>(SelectedGameMode);
        }
    }
}