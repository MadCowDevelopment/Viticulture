using System.Collections.Generic;
using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    public interface  IGrapesSelectionViewModel : IDialogViewModel<IEnumerable<Grape>> { }
}