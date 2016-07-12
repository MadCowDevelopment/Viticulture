using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public class Deck<T> : IDeck where T: Card
    {
        private readonly Hand _hand;
        private List<T> _cards;
        private List<T> _discard;

        public Deck(Hand hand, IEnumerable<T> cards)
        {
            _hand = hand;
            _cards = new List<T>(cards);
            _cards.ForEach(p => p.Deck = this);
            _cards.ForEach(p => p.Hand = _hand);
            _discard = new List<T>();

            _cards.Shuffle();
        }

        private Deck() { }

        public IEnumerable<T> Cards => _cards;

        public bool CanDraw(int number)
        {
            return _cards.Count + _discard.Count >= number;
        }

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

        public void Discard(Card card)
        {
            _discard.Add(card as T);
        }

        public Card TopCardOnDiscardPile => _discard.LastOrDefault();

        public void RemoveCard(Card card)
        {
            _cards.Remove(card as T);
            _discard.Remove(card as T);
        }

        public Deck<T> Clone()
        {
            var clone = new Deck<T>();
            clone._cards = _cards.Select(c => c.Clone()).OfType<T>().ToList();
            clone._discard = _discard.Select(c => c.Clone()).OfType<T>().ToList();
            return clone;
        }

        public void SetFromClone(Deck<T> clone, IEnumerable<Entity> entities)
        {
            _cards = new List<T>();
            foreach (var card in clone._cards)
            {
                _cards.Add(entities.OfType<T>().First(p => p.Id == card.Id));
            }

            _discard = new List<T>();
            foreach (var card in clone._discard)
            {
                _discard.Add(entities.OfType<T>().First(p => p.Id == card.Id));
            }
        }
    }

    public interface IDeck
    {
        void Discard(Card card);

        Card TopCardOnDiscardPile { get; }
        void RemoveCard(Card card);
    }
}