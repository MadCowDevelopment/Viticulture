using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.MakeWine
{
    [Export(typeof(Summer.SellGrapeOrField.IGrapesSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GrapesSelectionViewModel : DialogViewModel<IEnumerable<Grape>>, IGrapesSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public GrapesSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;

            RedGrapes = _gameState.RedGrapes.Where(p => p.IsBought).Select(p => new GrapeViewModel(p)).ToList();
            WhiteGrapes = _gameState.WhiteGrapes.Where(p => p.IsBought).Select(p => new GrapeViewModel(p)).ToList();
        }

        public IEnumerable<GrapeViewModel> RedGrapes { get; }

        public IEnumerable<GrapeViewModel> WhiteGrapes { get; }

        private IEnumerable<Grape> SelectedGrapes
            => RedGrapes.Union(WhiteGrapes).Where(p => p.IsSelected).Select(p => p.Grape);

        public void Done()
        {
            Close(SelectedGrapes);
        }

        public bool CanDone()
        {
            if (!SelectedGrapes.Any()) return false;
            if (SelectedGrapes.Count(p => p.GrapeColor == GrapeColor.White) > 1) return false;
            if (SelectedGrapes.Count(p => p.GrapeColor == GrapeColor.Red) > 2) return false;
            return true;
        }

        public void Cancel()
        {
            Close(Enumerable.Empty<Grape>());
        }
    }
}