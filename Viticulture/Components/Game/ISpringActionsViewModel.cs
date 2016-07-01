using System.Collections.Generic;

namespace Viticulture.Components.Game
{
    public interface ISpringActionsViewModel : IViewModel
    {
        IEnumerable<Benefit> Benefits { get; }

        void SelectBenefit(Benefit benefit);
    }
}