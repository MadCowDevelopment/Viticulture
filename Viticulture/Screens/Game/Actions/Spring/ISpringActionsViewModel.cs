using System.Collections.Generic;

namespace Viticulture.Screens.Game.Actions.Spring
{
    public interface ISpringActionsViewModel : IViewModel
    {
        IEnumerable<Benefit> Benefits { get; }

        void SelectBenefit(Benefit benefit);
    }
}