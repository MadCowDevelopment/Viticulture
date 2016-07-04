using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Cellar
{
    [Export(typeof(ICellarViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CellarViewModel : ViewModel, ICellarViewModel
    {
        [ImportingConstructor]
        public CellarViewModel()
        {
            
        }
    }
}