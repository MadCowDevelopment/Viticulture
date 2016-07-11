using System;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Visitors
{
    public interface ITwoChoicesViewModel : IDialogViewModel<Selection>
    {
        string Option1 { get; set; }
        string Option2 { get; set; }

        bool CanSelectOption1 { get; set; }

        bool CanSelectOption2 { get; set; }

        void Cancel();

        void SelectOption1();
        void SelectOption2();
    }
}