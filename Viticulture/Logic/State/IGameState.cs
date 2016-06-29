using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    public interface IGameState
    {
        Grande Grande { get; set; }
        int Money { get; set; }
        Irigation Irigation { get; set; }
    }
}