using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    [Export(typeof(IGrapesSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GrapesSelectionViewModel : DialogViewModel<IEnumerable<Grape>>, IGrapesSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public GrapesSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;

            RedGrapes = _gameState.RedGrapes.Where(p => p.IsBought).Select(p => new GrapeViewModel(p));
            WhiteGrapes = _gameState.WhiteGrapes.Where(p => p.IsBought).Select(p => new GrapeViewModel(p));
        }

        public IEnumerable<GrapeViewModel> RedGrapes { get; }

        public IEnumerable<GrapeViewModel> WhiteGrapes { get; }

        private IEnumerable<Grape> SelectedGrapes
            => RedGrapes.Union(WhiteGrapes).Where(p => p.IsChecked).Select(p => p.Grape);

        public void Done()
        {
            Close(SelectedGrapes);
        }

        public bool CanDone()
        {
            return SelectedGrapes.Any();
        }

        public void Cancel()
        {
            Close(Enumerable.Empty<Grape>());
        }
    }
}