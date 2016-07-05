using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public class Deck<T> where T: Card
    {
        private readonly Hand _hand;
        private readonly List<T> _cards;
        private readonly List<T> _discard;

        public Deck(Hand hand, IEnumerable<T> cards)
        {
            _hand = hand;
            _cards = new List<T>(cards);
            _discard = new List<T>();

            _cards.Shuffle();
        }

        private IEnumerable<T> Cards => _cards;

        public void DrawToHand()
        {
            _hand.AddCard(Draw());
        }

        public T Draw()
        {
            if (!_cards.Any())
            {
                _cards.AddRange(_discard);
                _discard.Clear();
                _cards.Shuffle();
            }

            var card = _cards.LastOrDefault();
            _cards.Remove(card);
            return card;
        }

        public void Discard(T card)
        {
            _discard.Add(card);
        }
    }
}