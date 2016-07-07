using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces.Buildings;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.BuildStructure
{
    [Export(typeof(IBuildStructureViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuildStructureViewModel : DialogViewModel<Building>, IBuildStructureViewModel
    {
        private readonly IGameState _gameState;
        private readonly List<Building> _structures;

        [ImportingConstructor]
        public BuildStructureViewModel(IGameState gameState)
        {
            _gameState = gameState;
            _structures = new List<Building>();
            foreach (var building in _gameState.Buildings)
            {
                if (building is LargeCellar && !_gameState.MediumCellar.IsBought) continue;
                _structures.Add(building);
            }
        }

        public IEnumerable<Building> Structures => _structures;

        public int BuildingBonus { get; set; }

        public void Buy(Building building)
        {
            Close(building);
        }

        public bool CanBuy(Building building)
        {
            return building.Cost <= _gameState.Money + BuildingBonus;
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}