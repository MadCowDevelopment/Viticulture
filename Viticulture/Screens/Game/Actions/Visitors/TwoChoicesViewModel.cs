using System;
using System.ComponentModel.Composition;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Visitors
{
    [Export(typeof(ITwoChoicesViewModel))]
    public class TwoChoicesViewModel : DialogViewModel<Selection>, ITwoChoicesViewModel
    {
        public string Option1 { get; set; }
        public string Option2 { get; set; }

        public bool CanSelectOption1 { get; set; }

        public bool CanSelectOption2 { get; set; }

        public void Cancel()
        {
            Close(Selection.None);
        }

        public void SelectOption1()
        {
            Close(Selection.Option1);
        }

        public void SelectOption2()
        {
            Close(Selection.Option2);
        }
    }
}