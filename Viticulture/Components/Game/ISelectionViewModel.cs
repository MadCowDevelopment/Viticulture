using Viticulture.Logic.Cards.Parents.Papas;

namespace Viticulture.Components.Game
{
    public interface ISelectionViewModel : IViewModel
    {
        string Title { get; set; }
        string Message { get; set; }
        string Option1 { get; set; }
        string Option2 { get; set; }

        Selection SelectedOption { get; set; }
    }
}