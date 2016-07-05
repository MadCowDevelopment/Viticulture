using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic;
using Viticulture.Logic.Actions;

namespace Viticulture.Screens.Game.Actions.Winter
{
    [Export(typeof(IWinterActionsViewModel))]
    public class WinterActionsViewModel : ViewModel, IWinterActionsViewModel
    {
        private readonly IGameLogic _gameLogic;

        [ImportingConstructor]
        public WinterActionsViewModel([ImportMany]IEnumerable<PlayerAction> actions, IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            Actions = actions.Where(p => p is IWinterAction).ToList();
        }

        public IEnumerable<PlayerAction> Actions { get; }

        public void EndTurn()
        {
            _gameLogic.EndSeason();
        }
    }
}