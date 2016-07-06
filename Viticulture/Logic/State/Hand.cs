using System.Collections.Generic;
using System.Linq;
using Viticulture.Logic.Cards;
using Viticulture.Logic.Cards.Vines;
using Viticulture.Utils;

namespace Viticulture.Logic.State
{
    public sealed class Hand : Entity
    {
        private List<Card> _cards = new List<Card>();

        public IEnumerable<Card> Cards => _cards;
        public IEnumerable<VineCard> Vines => Cards.OfType<VineCard>();

        public void AddCard(Card card)
        {
            _cards.AddNotNull(card);
        }

        public void RemoveCard(Card card)
        {
            _cards.Remove(card);
        }

        protected override void OnClone(Entity instance)
        {
            base.OnClone(instance);
            var hand = instance as Hand;
            hand._cards = _cards.Select(c => c.Clone()).OfType<Card>().ToList();
        }

        protected override void OnSetFromClone(Entity entity, IEnumerable<Entity> references)
        {
            base.OnSetFromClone(entity, references);
            var clone = entity as Hand;
            _cards = new List<Card>();
            foreach (var card in clone.Cards)
            {
                _cards.Add(references.OfType<Card>().First(p => p.Id == card.Id));
            }
        }
    }
}