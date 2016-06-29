using System.ComponentModel.Composition;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameState : IGameState
    {
        public Grande Grande { get; set; }
    }
}
