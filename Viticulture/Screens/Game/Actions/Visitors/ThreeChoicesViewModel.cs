using System.ComponentModel.Composition;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Visitors
{
    [Export(typeof(IThreeChoicesViewModel))]
    public class ThreeChoicesViewModel : TwoChoicesViewModel, IThreeChoicesViewModel
    {
        public string Option3 { get; set; }
        public bool CanSelectOption3 { get; set; }

        public void SelectOption3()
        {
            Close(Selection.Option3);
        }
    }
}