using System;
using System.ComponentModel.Composition;
using Viticulture.Components;

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

        public void NavigateTo<T>() where T : IViewModel
        {
            var screen = _container.GetExportedValue<T>();
            screen.Initialize();
            _appViewModel.Value.MainContent = screen;
        }

        public void NavigateTo<T, TInit>(TInit initObject) where T : IViewModel<TInit>
        {
            var screen = _container.GetExportedValue<T>();
            screen.Initialize(initObject);
            _appViewModel.Value.MainContent = screen;
        }
    }
}
