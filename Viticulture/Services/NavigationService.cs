using System;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Viticulture.Services
{
    [Export(typeof(INavigationService))]
    public class NavigationService : INavigationService
    {
        private readonly Lazy<IAppViewModel> _appViewModel;
        private readonly IMefContainer _container;

        [ImportingConstructor]
        public NavigationService(Lazy<IAppViewModel> appViewModel, IMefContainer container)
        {
            _appViewModel = appViewModel;
            _container = container;
        }

        public void NavigateTo<T>() where T : IScreen
        {
            var screen = _container.GetExportedValue<T>();
            _appViewModel.Value.MainContent = screen;
        }
    }
}
