using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class ProducerCard : VisitorCard
    {
        public override string Description => "Pay 2 lira to retrieve up to 2 workers from other actions.";
        public override string Name => "Producer";
        public override Season Season => Season.Summer;
        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Money >= 2 && gameState.Workers.Any(p => p.HasBeenUsed);
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var options =
                gameState.Workers.Where(p => p.HasBeenUsed).Select(p => new Option<Worker>(p, p.UsedAction.Text));
            var selectedWorkers =
                (await PlayerSelection.SelectMany(options, 2, SelectionRequirement.AtLeastOne)).OfType<Option<Worker>>()
                    .Select(p => p.WrappedObject).ToList();
            if (!selectedWorkers.Any()) return false;

            foreach (var selectedWorker in selectedWorkers)
            {
                if (gameState.Grande.UsedAction != selectedWorker.UsedAction)
                {
                    selectedWorker.UsedAction.HasBeenUsed = false;
                }

                selectedWorker.UsedAction = null;
                selectedWorker.HasBeenUsed = false;
            }

            return true;
        }
    }
}