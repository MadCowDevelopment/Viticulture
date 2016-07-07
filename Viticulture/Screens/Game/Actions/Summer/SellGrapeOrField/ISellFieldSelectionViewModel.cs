using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    public interface ISellFieldSelectionViewModel : IDialogViewModel<Field>
    {
        void Select(Field field);
        void Cancel();
    }
}