using System.Collections.Generic;
using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.MakeWine
{
    public interface  IGrapesSelectionViewModel : IDialogViewModel<IEnumerable<Grape>> { }
}