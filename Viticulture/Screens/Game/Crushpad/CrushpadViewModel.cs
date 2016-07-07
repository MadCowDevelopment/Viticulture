using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Crushpad
{
    [Export(typeof(ICrushpadViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CrushpadViewModel : ViewModel, ICrushpadViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public CrushpadViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<Grape> RedGrapes => _gameState.RedGrapes;
        public IEnumerable<Grape> WhiteGrapes => _gameState.WhiteGrapes;
    }

}