using System.Threading.Tasks;
using Viticulture.Logic.State;
using Viticulture.Utils;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class PatronCard : TwoChoicesVisitorCard
    {
        public override string Name => "Patron";
        public override Season Season => Season.Summer;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money += 4;
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            gameState.OrderDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
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

        protected override string Option1 => "gain 4 lira";
        protected override string Option2 => "draw 1 order and 1 winter visitor";
    }
}