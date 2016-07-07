using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField
{
    [Export(typeof(ISellFieldSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SellFieldSelectionViewModel : DialogViewModel<Field>, ISellFieldSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public SellFieldSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<Field> Fields => _gameState.Fields.Where(p => p.IsBought && !p.Vines.Any());

        public void Select(Field field)
        {
            Close(field);
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}