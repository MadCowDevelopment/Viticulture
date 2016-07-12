using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class OrderBenefit : Benefit
    {
        public override string Name => "Order card";
        public override void OnApply(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
        }
    }
}