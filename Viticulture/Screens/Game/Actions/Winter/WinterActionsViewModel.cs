using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Actions.Winter
{
    [Export(typeof(IWinterActionsViewModel))]
    public class WinterActionsViewModel : ViewModel, IWinterActionsViewModel
    {
        
    }
}