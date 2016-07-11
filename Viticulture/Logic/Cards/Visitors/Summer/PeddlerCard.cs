using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Summer
{
    public class PeddlerCard : VisitorCard
    {
        public override string Description => "discard 2 cards to draw 1 of each type of card";
        public override string Name => "Peddler";
        public override Season Season => Season.Summer;
        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Hand.Cards.Count() >= 2;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var options = gameState.Hand.VisitorCards.Select(p => new Option<Card>(p, p.DisplayText));
            var selectedCards =
                (await PlayerSelection.SelectMany(options, 2)).OfType<Option<Card>>().ToList();
            if (selectedCards.Count != 2) return false;
            selectedCards.ForEach(p => p.WrappedObject.Discard());

            gameState.VineDeck.DrawToHand();
            gameState.OrderDeck.DrawToHand();
            gameState.SummerVisitorDeck.DrawToHand();
            gameState.WinterVisitorDeck.DrawToHand();

            return true;
        }
    }
}