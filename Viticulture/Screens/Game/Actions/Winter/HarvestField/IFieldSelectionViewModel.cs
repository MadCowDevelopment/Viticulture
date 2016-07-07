using System.Collections.Generic;
using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.HarvestField
{
    public interface IFieldSelectionViewModel : IDialogViewModel<Field>
    {
        IEnumerable<Field> Fields { get; }
        void Select(Field field);
        void Cancel();
    }
}