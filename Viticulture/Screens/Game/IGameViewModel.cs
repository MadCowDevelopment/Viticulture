using Viticulture.Logic.GameModes;
using Viticulture.Screens.Game.Actions;
using Viticulture.Screens.Game.Cellar;
using Viticulture.Screens.Game.Crushpad;
using Viticulture.Screens.Game.Hand;
using Viticulture.Screens.Game.PlayerStatus;
using Viticulture.Screens.Game.Structures;

namespace Viticulture.Screens.Game
{
    public interface IGameViewModel : IViewModel<IGameMode>
    {
        IPlayerStatusViewModel PlayerStatus { get; }
        IActionsViewModel Actions { get; }
        IHandViewModel Visitors { get; }
        IStructuresViewModel Structures { get; }
        ICrushpadViewModel Crushpad { get; }
        ICellarViewModel Cellar { get; }
    }
}