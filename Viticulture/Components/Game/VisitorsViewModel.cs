using System.ComponentModel.Composition;

namespace Viticulture.Components.Game
{
    [Export(typeof(IVisitorsViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class VisitorsViewModel : ViewModel, IVisitorsViewModel
    {
        [ImportingConstructor]
        public VisitorsViewModel()
        {
            DisplayName = "Visitors";
        }
    }
}