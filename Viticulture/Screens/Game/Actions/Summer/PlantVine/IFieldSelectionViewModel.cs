using System.Collections.Generic;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.PlantVine
{
    public interface IFieldSelectionViewModel : IDialogViewModel<Field>
    {
        IEnumerable<Field> Fields { get; }
        VineCard VineToPlant { get; set; }
        void Select(Field field);
        bool CanSelect(Field field);
        void Cancel();
    }
}