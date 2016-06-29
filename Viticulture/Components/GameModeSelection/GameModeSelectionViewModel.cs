using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Components.Game;
using Viticulture.Components.MainMenu;
using Viticulture.Logic.GameModes;
using Viticulture.Services;

namespace Viticulture.Components.GameModeSelection
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