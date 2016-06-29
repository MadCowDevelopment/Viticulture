using System.Collections.Generic;
using Viticulture.Logic.Cards;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public class Hand
    {
        private readonly List<Card> _cards = new List<Card>();

        private IEnumerable<Card> Cards => _cards;

        public void AddCard(Card card)
        {
            _cards.AddNotNull(card);
        }
    }
}