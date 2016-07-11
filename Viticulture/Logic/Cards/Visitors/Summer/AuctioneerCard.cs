using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class AuctioneerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Auctioneer";
        public override Season Season => Season.Summer;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            return SelectCardsToDiscard(gameState, 2);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            return SelectCardsToDiscard(gameState, 4);
        }

        private async Task<bool> SelectCardsToDiscard(IGameState gameState, int numberOfCardsToDiscard)
        {
            var options = gameState.Hand.Cards.Select(p => new Option<Card>(p, p.DisplayText));
            var selectedCards =
                (await PlayerSelection.SelectMany(options, numberOfCardsToDiscard)).OfType<Option<Card>>().ToList();
            if (!selectedCards.Any()) return false;
            selectedCards.ForEach(p => p.WrappedObject.Discard());

            return true;
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Hand.Cards.Count() >= 2;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Cards.Count() >= 4;
        }

        protected override string Option1 => "discard 2 cards to gain 4 lira";
        protected override string Option2 => "discard 4 cards to gain 3 VP";
    }
}