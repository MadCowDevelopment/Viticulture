using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class UncertifiedBrokerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Uncertified Broker";
        public override Season Season => Season.Summer;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.VictoryPoints -= 3;
            gameState.Money += 9;
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.Money -= 6;
            gameState.VictoryPoints += 2;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.VictoryPoints >= GameState.MinimumVictoryPoints + 3;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Money >= 6;
        }

        protected override string Option1 => "lose 3 VP to gain 9 lira";
        protected override string Option2 => "pay 6 lira to gain 2 VP";
    }
}