using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;

namespace Viticulture.Logic.State
{
    public class Deck
    {
        private readonly Hand _hand;
        private readonly List<Card> _cards;

        public Deck(Hand hand, IEnumerable<Card> cards)
        {
            _hand = hand;
            _cards = new List<Card>(cards);
        }

        private IEnumerable<Card> Cards => _cards;

        public void DrawToHand()
        {
            _hand.AddCard(_cards.LastOrDefault());
        }
    }
}