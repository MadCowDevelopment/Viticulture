using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class BrokerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Broker";

        public override Season Season => Season.Summer;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money -= 9;
            gameState.VictoryPoints += 3;
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.VictoryPoints -= 2;
            gameState.Money += 6;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 9;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.VictoryPoints >= GameState.MinimumVictoryPoints + 2;
        }

        protected override string Option1 => "pay 9 lira to gain 3 VP";
        protected override string Option2 => "lose 2 VP to gain 6 lira";
    }
}