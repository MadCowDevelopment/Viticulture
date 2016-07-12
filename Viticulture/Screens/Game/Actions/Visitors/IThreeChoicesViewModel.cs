namespace Viticulture.Screens.Game.Actions.Visitors
{
    public interface IThreeChoicesViewModel : ITwoChoicesViewModel
    {
        string Option3 {get; set; }
        bool CanSelectOption3 { get; set; }
        void SelectOption3();
    }
}