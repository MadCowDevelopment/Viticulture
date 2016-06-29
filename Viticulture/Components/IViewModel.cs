using Caliburn.Micro;

namespace Viticulture.Components
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