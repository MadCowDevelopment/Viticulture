using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Cellar
{
    [Export(typeof(ICellarViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CellarViewModel : ViewModel, ICellarViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public CellarViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<Wine> RedWines1 => _gameState.RedWines.Take(3);
        public IEnumerable<Wine> RedWines2 => _gameState.RedWines.Skip(3).Take(3);
        public IEnumerable<Wine> RedWines3 => _gameState.RedWines.Skip(6).Take(3);
        public IEnumerable<Wine> WhiteWines1 => _gameState.WhiteWines.Take(3);
        public IEnumerable<Wine> WhiteWines2 => _gameState.WhiteWines.Skip(3).Take(3);
        public IEnumerable<Wine> WhiteWines3 => _gameState.WhiteWines.Skip(6).Take(3);
        public IEnumerable<Wine> BlushWines1 => _gameState.BlushWines.Take(3);
        public IEnumerable<Wine> BlushWines2 => _gameState.BlushWines.Skip(3).Take(3);
        public IEnumerable<Wine> SparklingWines => _gameState.SparklingWines;
    }
}