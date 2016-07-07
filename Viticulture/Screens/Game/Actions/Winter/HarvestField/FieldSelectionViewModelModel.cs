using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.HarvestField
{
    [Export(typeof(IFieldSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class FieldSelectionViewModel : DialogViewModel<Field>, IFieldSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public FieldSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<Field> Fields => _gameState.Fields;

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