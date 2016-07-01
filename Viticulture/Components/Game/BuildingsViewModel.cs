using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(IBuildingsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuildingsViewModel : ViewModel, IBuildingsViewModel
    {
        [ImportingConstructor]
        public BuildingsViewModel()
        {
            
        }
    }
}