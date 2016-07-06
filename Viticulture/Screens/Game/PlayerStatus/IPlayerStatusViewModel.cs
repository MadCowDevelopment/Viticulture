namespace Viticulture.Screens.Game.PlayerStatus
{
    public interface IPlayerStatusViewModel : IViewModel
    {
        int Lira { get; }
        int Workers { get; }
        int Round { get; }
        int Bonus { get; }
        int VictoryPoints { get; }
        int Residual { get; }
        int Grande { get; }
    }
}