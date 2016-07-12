using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class WorkerBenefit : Benefit
    {
        public override string Name => "Neutral worker";

        public override void OnApply(IGameState gameState)
        {
            gameState.NeutralWorker.IsBought = true;
        }
    }
}