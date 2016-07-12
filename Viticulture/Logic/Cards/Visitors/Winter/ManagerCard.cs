using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class ManagerCard : VisitorCard
    {
        public override string Description => "Take any summer action without placing a worker";
        public override string Name => "Manager";
        public override Season Season => Season.Winter;

        [ImportMany]
        public IEnumerable<PlayerAction> Actions { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return true;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var selectedAction =
                await
                    PlayerSelection.Select("Select action", "Choose a summer action to execute",
                        Actions.OfType<ISummerAction>().OfType<PlayerAction>());
            if (selectedAction == null) return false;

            return await selectedAction.OnExecute();
        }
    }
}