using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Buildings
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