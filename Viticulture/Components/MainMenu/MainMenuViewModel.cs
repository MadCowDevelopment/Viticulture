using System.ComponentModel.Composition;
using System.Net.Mime;
using System.Windows;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;

namespace Viticulture.Components.MainMenu
{
    [Export(typeof(IMainMenuViewModel))]
    public class MainMenuViewModel : Screen, IMainMenuViewModel
    {
        private readonly IWindowManager _windowManager;
        private readonly IMetroDialog _metroDialog;

        [ImportingConstructor]
        public MainMenuViewModel(IWindowManager windowManager, IMetroDialog metroDialog)
        {
            _windowManager = windowManager;
            _metroDialog = metroDialog;
        }

        public void StartGame()
        {
            
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