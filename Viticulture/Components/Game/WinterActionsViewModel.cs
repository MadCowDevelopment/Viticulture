using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(IWinterActionsViewModel))]
    public class WinterActionsViewModel : ViewModel, IWinterActionsViewModel
    {
        
    }
}