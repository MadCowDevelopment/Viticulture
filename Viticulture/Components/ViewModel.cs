using Caliburn.Micro;

namespace Viticulture.Components
{
    public abstract class ViewModel<T> : ViewModel, IViewModel<T>
    {
        public virtual void Initialize(T initObject)
        {
        }
    }

    public abstract class ViewModel : Screen, IViewModel
    {
        public virtual void Initialize()
        {
        }
    }
}