namespace Viticulture.Screens.Game.Actions
{
    public interface IActionsViewModel : IViewModel
    {
        string CurrentSeason { get; }

        IViewModel CurrentActions { get; }
    }
}