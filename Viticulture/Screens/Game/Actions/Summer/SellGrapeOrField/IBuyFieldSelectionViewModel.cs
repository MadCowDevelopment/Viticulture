using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    public interface IBuyFieldSelectionViewModel : IDialogViewModel<Field>
    {
        void Select(Field field);
        void Cancel();
    }
}