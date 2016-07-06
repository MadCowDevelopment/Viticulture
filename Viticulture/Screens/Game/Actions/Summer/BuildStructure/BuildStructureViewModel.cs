using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Pieces.Buildings;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.BuildStructure
{
    [Export(typeof(IBuildStructureViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BuildStructureViewModel : DialogViewModel, IBuildStructureViewModel
    {
        private readonly IGameState _gameState;
        private readonly IMetroDialog _metroDialog;
        private readonly List<Building> _structures;

        [ImportingConstructor]
        public BuildStructureViewModel(IGameState gameState, IMetroDialog metroDialog)
        {
            _gameState = gameState;
            _metroDialog = metroDialog;
            _structures = gameState.Buildings.Where(p => !p.IsBought).ToList();
        }

        public IEnumerable<Building> Structures => _structures;

        public int BuildingBonus { get; set; }

        public void Buy(Building building)
        {
            if (_gameState.Money + BuildingBonus >= building.Cost)
            {
                building.IsBought = true;
                _gameState.Money -= Math.Max(building.Cost - BuildingBonus, 0);
                Close();
            }
            else
            {
                _metroDialog.ShowMessage("Build structure", "You cannot afford to build that structure.");
            }
        }

        public void Cancel()
        {
            Close();
        }
    }
}