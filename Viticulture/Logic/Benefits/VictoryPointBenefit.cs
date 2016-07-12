using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class VictoryPointBenefit : Benefit
    {
        public override string Name => "1 VP";

        public override void OnApply(IGameState gameState)
        {
            gameState.VictoryPoints++;
        }
    }
}