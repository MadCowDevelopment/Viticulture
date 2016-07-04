using System.ComponentModel.Composition;

namespace Viticulture.Screens.Game.Hand
{
    [Export(typeof(IHandViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class HandViewModel : ViewModel, IHandViewModel
    {
        [ImportingConstructor]
        public HandViewModel()
        {
            DisplayName = "Hand";
        }
    }
}