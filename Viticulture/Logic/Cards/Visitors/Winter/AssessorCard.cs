using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class AssessorCard : TwoChoicesVisitorCard
    {
        public override string Name => "Assessor";
        public override Season Season => Season.Winter;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += gameState.Hand.Cards.Count();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.Hand.Cards.ToList().ForEach(p => p.Discard());
            gameState.VictoryPoints += 2;
            return Task.FromResult(true);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Cards.Any();
        }

        protected override string Option1 => "gain 1 lira for each card in your hand";
        protected override string Option2 => "discard your hand (minimum 1) to gain 2 VP";
    }
}