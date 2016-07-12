using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards
{
    public abstract class Card : Entity
    {
        public abstract string Name { get; }

        public override string DisplayText => Name;

        public IDeck Deck { get; set; }

        public Hand Hand { get; set; }

        public void Discard()
        {
            Hand.RemoveCard(this);
            Deck.Discard(this);
        }

        public void TakeToHand()
        {
            Hand.AddCard(this);
            Deck.RemoveCard(this);
        }
    }
}
