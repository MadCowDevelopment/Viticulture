using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic;
using Viticulture.Logic.Actions;

namespace Viticulture.Screens.Game.Actions.Summer
{
    [Export(typeof(ISummerActionsViewModel))]
    public class SummerActionsViewModel : ViewModel, ISummerActionsViewModel
    {
        private readonly IGameLogic _gameLogic;

        [ImportingConstructor]
        public SummerActionsViewModel([ImportMany]IEnumerable<PlayerAction> actions, IGameLogic gameLogic)
        {
            _gameLogic = gameLogic;
            Actions = actions.Where(p => p is ISummerAction).ToList();
        }

        public IEnumerable<PlayerAction> Actions { get; }

        public void EndTurn()
        {
            _gameLogic.EndSeason();
        }
    }
}