using System.ComponentModel.Composition;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.State
{
    [Export(typeof(IGameState))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class GameState : PropertyChangedBase, IGameState
    {
        [ImportingConstructor]
        public GameState()
        {
            Grande = new Grande();
            Irigation = new Irigation();
        }

        public Grande Grande { get; set; }
        public int Money { get; set; }
        public Irigation Irigation { get; set; }
    }
}
