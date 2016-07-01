using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
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