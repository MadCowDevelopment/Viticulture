using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Screens.MainMenu;

namespace Viticulture
{
    [Export(typeof(IAppViewModel))]
    public class AppViewModel : PropertyChangedBase, IHaveDisplayName, IAppViewModel
    {
        private readonly IWindowManager _windowManager;

        private readonly IMainMenuViewModel _mainMenuViewModel;

        [ImportingConstructor]
        public AppViewModel(IWindowManager windowManager, IMainMenuViewModel mainMenuViewModel)
        {
            _windowManager = windowManager;
            _mainMenuViewModel = mainMenuViewModel;

            MainContent = _mainMenuViewModel;
        }

        public string DisplayName { get; set; } = "Viticulture - Essential Edition";

        public IScreen MainContent { get; set; }
    }
}