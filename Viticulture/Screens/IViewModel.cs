using Caliburn.Micro;

namespace Viticulture.Screens
{
    public interface IViewModel<in T> : IViewModel
    {
        void Initialize(T initObject);
    }

    public interface IViewModel : IScreen
    {
        void Initialize();
    }
}