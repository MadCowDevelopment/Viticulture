using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.PlantVine
{
    [Export(typeof(IVineSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class VineSelectionViewModel : DialogViewModel<VineCard>, IVineSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public VineSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<VineCard> Vines => _gameState.Hand.Vines;

        public bool IgnoreRequirements { get; set; }

        public void Select(VineCard vine)
        {
            Close(vine);
        }

        public bool CanSelect(VineCard vine)
        {
            return IgnoreRequirements || (!vine.RequiresIrigation || _gameState.Irigation.IsBought) &&
                   (!vine.RequiresTrellis || _gameState.Trellis.IsBought);
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}