using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces.Structures;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Structures
{
    [Export(typeof(IStructuresViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StructuresViewModel : ViewModel, IStructuresViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public StructuresViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<Structure> Structures => _gameState.Structures;
    }
}