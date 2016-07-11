using Viticulture.Logic.Pieces.Structures;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Summer.BuildStructure
{
    public interface IBuildStructureViewModel : IDialogViewModel<Structure>
    {
        int BuildingBonus { get; set; }
    }
}