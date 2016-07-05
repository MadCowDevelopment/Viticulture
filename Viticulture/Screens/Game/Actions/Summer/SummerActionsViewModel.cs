using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Actions;
using Viticulture.Logic.State;

namespace Viticulture.Screens.Game.Actions.Summer
{
    [Export(typeof(ISummerActionsViewModel))]
    public class SummerActionsViewModel : ViewModel, ISummerActionsViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public SummerActionsViewModel([ImportMany]IEnumerable<PlayerAction> actions, IGameState gameState)
        {
            _gameState = gameState;
            Actions = actions.Where(p => p is ISummerAction).ToList();
        }

        public IEnumerable<PlayerAction> Actions { get; }

        public void EndTurn()
        {
            _gameState.Season++;
        }
    }
}