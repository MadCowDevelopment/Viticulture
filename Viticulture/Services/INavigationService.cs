using Caliburn.Micro;

namespace Viticulture.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>() where T : IScreen;
    }
}