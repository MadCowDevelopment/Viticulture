using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Crushpad
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