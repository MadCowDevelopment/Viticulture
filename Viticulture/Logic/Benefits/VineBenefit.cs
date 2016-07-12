using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class VineBenefit : Benefit
    {
        public override string Name => "Vine card";
        public override void OnApply(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
        }
    }
}