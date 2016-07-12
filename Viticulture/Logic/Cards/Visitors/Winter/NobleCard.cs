using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class NobleCard : TwoChoicesVisitorCard
    {
        public override string Name => "Noble";
        public override Season Season => Season.Winter;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money--;
            gameState.ResidualMoney++;
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.ResidualMoney -= 2;
            gameState.VictoryPoints += 2;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 1;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.ResidualMoney >= 2;
        }

        protected override string Option1 => "pay 1 lira to gain 1 residual";
        protected override string Option2 => "lose 2 residual to gain 2 VP";
    }
}