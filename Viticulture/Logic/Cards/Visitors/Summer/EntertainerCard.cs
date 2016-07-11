using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class EntertainerCard : TwoChoicesVisitorCard
    {
        public override string Name => "Entertainer";
        public override Season Season => Season.Summer;
        protected override Task<bool> ApplyOption1(IGameState gameState)
        {
            gameState.Money -= 4;
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();
            return Task.FromResult(true);
        }

        protected override async Task<bool> ApplyOption2(IGameState gameState)
        {
            var selectedWine =
                await
                    PlayerSelection.Select("Select wine", "Choose which wine to discard",
                        gameState.Wines.Where(p => p.IsBought));
            if (selectedWine == null) return false;
            return await SelectCardsToDiscard(gameState, 3);
        }

        protected override bool CanApplyOption1(IGameState gameState)
        {
            return gameState.Money >= 4;
        }

        protected override bool CanApplyOption2(IGameState gameState)
        {
            return gameState.Wines.Count(p => p.IsBought) >= 1 &&
                   gameState.Hand.Cards.OfType<VisitorCard>().Count() >= 3;
        }

        private async Task<bool> SelectCardsToDiscard(IGameState gameState, int numberOfCardsToDiscard)
        {
            var options = gameState.Hand.VisitorCards.Select(p => new Option<Card>(p, p.DisplayText));
            var selectedCards =
                (await PlayerSelection.SelectMany(options, numberOfCardsToDiscard)).OfType<Option<Card>>().ToList();
            if (!selectedCards.Any()) return false;
            selectedCards.ForEach(p => p.WrappedObject.Discard());

            return true;
        }

        protected override string Option1 => "pay 4 lira to draw 3 winter visitors";

        protected override string Option2 => "discard 1 wine and 3 visitor cards to gain 3 VP";
    }
}