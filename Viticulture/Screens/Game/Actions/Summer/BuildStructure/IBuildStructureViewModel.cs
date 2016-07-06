using Viticulture.Logic.Pieces.Buildings;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.BuildStructure
{
    public interface IBuildStructureViewModel : IDialogViewModel<Building>
    {
        int BuildingBonus { get; set; }
    }
}