using Viticulture.Components;

namespace Viticulture.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : IViewModel;

        void NavigateTo<T, TInit>(TInit initObject) where T : IViewModel<TInit>;
    }
}