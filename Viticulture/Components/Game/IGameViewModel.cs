using Viticulture.Logic.GameModes;

namespace Viticulture.Components.Game
{
    public interface IGameViewModel : IViewModel<IGameMode>
    {
        IPlayerStatusViewModel PlayerStatus { get; }
        IActionsViewModel Actions { get; }
        IVisitorsViewModel Visitors { get; }
        IBuildingsViewModel Buildings { get; }
        ICrushpadViewModel Crushpad { get; }
        ICellarViewModel Cellar { get; }
    }
}