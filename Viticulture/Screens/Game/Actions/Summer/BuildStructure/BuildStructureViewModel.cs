using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces.Structures;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.BuildStructure
{
    [Export(typeof(IBuildStructureViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuildStructureViewModel : DialogViewModel<Structure>, IBuildStructureViewModel
    {
        private readonly IGameState _gameState;
        private readonly List<Structure> _structures;

        [ImportingConstructor]
        public BuildStructureViewModel(IGameState gameState)
        {
            _gameState = gameState;
            _structures = new List<Structure>();
            foreach (var structure in _gameState.Structures)
            {
                if (structure is LargeCellar && !_gameState.MediumCellar.IsBought) continue;
                _structures.Add(structure);
            }
        }

        public IEnumerable<Structure> Structures => _structures;

        public int BuildingBonus { get; set; }

        public void Buy(Structure structure)
        {
            Close(structure);
        }

        public bool CanBuy(Structure structure)
        {
            return structure.Cost <= _gameState.Money + BuildingBonus;
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}