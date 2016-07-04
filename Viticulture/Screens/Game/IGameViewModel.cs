using Viticulture.Logic.GameModes;
using Viticulture.Screens.Game.Actions;
using Viticulture.Screens.Game.Buildings;
using Viticulture.Screens.Game.Cellar;
using Viticulture.Screens.Game.Crushpad;
using Viticulture.Screens.Game.Hand;
using Viticulture.Screens.Game.PlayerStatus;

namespace Viticulture.Screens.Game
{
    public interface IGameViewModel : IViewModel<IGameMode>
    {
        IPlayerStatusViewModel PlayerStatus { get; }
        IActionsViewModel Actions { get; }
        IHandViewModel Visitors { get; }
        IBuildingsViewModel Buildings { get; }
        ICrushpadViewModel Crushpad { get; }
        ICellarViewModel Cellar { get; }
    }
}