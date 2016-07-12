using System.Linq;
using System.Threading.Tasks;
using Viticulture.Logic.Cards.Visitors.Summer;
using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards.Visitors.Winter
{
    public class InnkeeperCard : VisitorCard
    {
        public override string Description
            => "As you play this card put the top card of two different discard piles into your hand";

        public override string Name => "Innkeeper";
        public override Season Season => Season.Winter;

        public override bool CanPlay(IGameState gameState)
        {
            return gameState.Decks.Count(p => p.TopCardOnDiscardPile != null) >= 2;
        }

        protected override async Task<bool> OnApply(IGameState gameState)
        {
            var options =
                gameState.Decks.Select(p => p.TopCardOnDiscardPile)
                    .Where(p => p != null)
                    .Select(p => new Option<Card>(p, p.Name)).ToList();
            var selectedCards =
                (await PlayerSelection.SelectMany(options, 2)).OfType<Option<Card>>()
                    .Select(p => p.WrappedObject)
                    .ToList();
            if (selectedCards.Count != 2) return false;
            foreach (var selectedCard in selectedCards)
            {
                selectedCard.TakeToHand();
            }

            return true;
        }
    }
}