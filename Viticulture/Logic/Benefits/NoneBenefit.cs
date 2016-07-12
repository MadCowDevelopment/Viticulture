using Viticulture.Logic.State;

namespace Viticulture.Logic.Benefits
{
    public class NoneBenefit : Benefit
    {
        public override string Name => "None";

        public override void OnApply(IGameState gameState)
        {
        }
    }
}