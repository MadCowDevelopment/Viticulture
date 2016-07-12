using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class SponsorCard : TwoChoicesVisitorCard
    {
        public override string Name => "Sponsor";
        public override Season Season => Season.Summer;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.VineDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.Money += 3;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return true;
        }

        protected override string DoBothCost => "1 VP";

        protected override bool CanDoBoth(IGameState gameState)
        {
            return gameState.VictoryPoints > GameState.MinimumVictoryPoints;
        }

        protected override void ApplyCostforDoingBoth(IGameState gameState)
        {
            base.ApplyCostforDoingBoth(gameState);
            gameState.VictoryPoints--;
        }

        protected override string Option1 => "draw 2 vines";
        protected override string Option2 => "gain 3 lira";
    }
}