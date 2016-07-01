using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(ISummerActionsViewModel))]
    public class SummerActionsViewModel : ViewModel, ISummerActionsViewModel
    {
        
    }
}