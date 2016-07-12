using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class LiraBenefit : Benefit
    {
        public override string Name => "1 Lira";
        public override void OnApply(IGameState gameState)
        {
            gameState.Money++;
        }
    }
}