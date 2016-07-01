using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public class Deck
    {
        private readonly Hand _hand;
        private readonly List<Card> _cards;
        private readonly List<Card> _discard;

        public Deck(Hand hand, IEnumerable<Card> cards)
        {
            _hand = hand;
            _cards = new List<Card>(cards);
            _discard = new List<Card>();

            _cards.Shuffle();
        }

        private IEnumerable<Card> Cards => _cards;

        public void DrawToHand()
        {
            _hand.AddCard(Draw());
        }

        public Card Draw()
        {
            if (_cards.Any())
            {
                _cards.AddRange(_discard);
                _discard.Clear();
                _cards.Shuffle();
            }

            return _cards.LastOrDefault();
        }
    }
}