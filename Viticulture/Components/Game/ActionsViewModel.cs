using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(IActionsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActionsViewModel : ViewModel, IActionsViewModel
    {
        
    }
}