using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.PlantVine
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

        public VineCard VineToPlant { get; set; }

        public bool IgnoreMaxValue { get; set; }

        public void Select(Field field)
        {
            IgnoreMaxValue = false;
            Close(field);
        }

        public bool CanSelect(Field field)
        {
            return IgnoreMaxValue || field.CanPlant(VineToPlant);
        }

        public void Cancel()
        {
            IgnoreMaxValue = false;
            Close(null);
        }
    }
}