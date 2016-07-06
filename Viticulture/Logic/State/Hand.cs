using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public class Hand
    {
        private readonly List<Card> _cards = new List<Card>();

        private IEnumerable<Card> Cards => _cards;
        public IEnumerable<VineCard> Vines => Cards.OfType<VineCard>();

        public void AddCard(Card card)
        {
            _cards.AddNotNull(card);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }
    }
}