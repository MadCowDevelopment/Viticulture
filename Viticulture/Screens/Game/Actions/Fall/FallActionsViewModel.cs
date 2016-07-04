using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Actions.Fall
{
    [Export(typeof(IFallActionsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FallActionsViewModel : ViewModel, IFallActionsViewModel
    {
    }
}