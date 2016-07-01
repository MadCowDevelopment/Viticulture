namespace Viticulture.Components.Game
{
    public interface IActionsViewModel : IViewModel
    {
        string CurrentSeason { get; }

        IViewModel CurrentActions { get; }
    }
}