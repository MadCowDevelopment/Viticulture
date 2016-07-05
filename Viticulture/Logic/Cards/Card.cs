using Viticulture.Logic.State;

namespace Viticulture.Logic.Cards
{
    public abstract class Card
    {
        public abstract string Name { get; }

        public abstract string Text { get; }

        public IDeck Deck { get; set; }

        public void Discard()
        {
            Deck.Discard(this);
        }
    }
}
