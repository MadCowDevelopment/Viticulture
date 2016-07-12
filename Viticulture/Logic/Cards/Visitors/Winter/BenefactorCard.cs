using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class BenefactorCard : TwoChoicesVisitorCard
    {
        public override string Name => "Benefactor";
        public override Season Season => Season.Winter;

        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.VineDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override Task<bool> ApplyOption2(IGameState gameState)
        {
            return SelectCardsToDiscard(gameState, 2);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return true;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Hand.Cards.Count() >= 2;
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

        protected override string Option1 => "draw 1 vine and 1 summer visitor";
        protected override string Option2 => "discard 2 visitors to gain 1 VP";
    }
}