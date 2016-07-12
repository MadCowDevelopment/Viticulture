using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Actions;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class PlannerCard : VisitorCard
    {
        public override string Description { get; }
        public override string Name { get; }
        public override Season Season { get; }

        [ImportMany]
        public IEnumerable<PlayerAction> AllActions { get; set; }

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.GetFirstAvailableWorker() != null;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var selectedAction =
                await
                    PlayerSelection.Select("Select action", "Choose which action you want to plan for.",
                        AllActions.OfType<IWinterAction>().Cast<PlayerAction>());
            if (selectedAction == null) return false;

            var worker = gameState.GetFirstAvailableWorker();
            worker.HasBeenUsed = true;
            worker.PlannedAction = selectedAction;
            return true;
        }
    }
}