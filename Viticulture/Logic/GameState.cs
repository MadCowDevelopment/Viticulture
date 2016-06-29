using System.ComponentModel.Composition;

namespace Viticulture.Logic
{
    [Export(typeof(IGameState))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameState : IGameState
    {
    }

    public interface IGameState
    {
    }
}
