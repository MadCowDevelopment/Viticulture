using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(ICrushpadViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CrushpadViewModel : ViewModel, ICrushpadViewModel
    {
        [ImportingConstructor]
        public CrushpadViewModel()
        {
        }
    }
}