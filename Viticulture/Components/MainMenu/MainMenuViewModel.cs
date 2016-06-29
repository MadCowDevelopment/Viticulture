using System.ComponentModel.Composition;
using System.Net.Mime;
using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Components.GameModeSelection;
using Viticulture.Services;

namespace Viticulture.Components.MainMenu
{
    [Export(typeof(IMainMenuViewModel))]
    public class MainMenuViewModel : ViewModel, IMainMenuViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IMetroDialog _metroDialog;

        [ImportingConstructor]
        public MainMenuViewModel(INavigationService navigationService, IMetroDialog metroDialog)
        {
            _navigationService = navigationService;
            _metroDialog = metroDialog;
        }

        public void StartGame()
        {
            _navigationService.NavigateTo<IGameModeSelectionViewModel>();
        }

        public void Settings()
        {
            
        }

        public async void Quit()
        {
            var result = await _metroDialog.ShowMessage("Quit", "Do you really want to quit?",
                MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            { 
                Application.Current.Shutdown();
            }
        }
    }
}