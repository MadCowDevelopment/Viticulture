namespace Viticulture.Components.Game
{
    public interface IPlayerStatusViewModel : IViewModel
    {
        int Lira { get; }
        int Workers { get; }
        int Round { get; }
        int Bonus { get; }
    }
}