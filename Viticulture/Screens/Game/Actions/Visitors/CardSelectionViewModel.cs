using System.Collections.Generic;
using System.ComponentModel.Composition;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Visitors
{
    [Export(typeof(ICardSelectionViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CardSelectionViewModel : DialogViewModel<VisitorCard>, ICardSelectionViewModel
    {
        public IEnumerable<VisitorCard> Cards { get; private set; }

        public void Play(VisitorCard card)
        {
            Close(card);
        }

        public void Cancel()
        {
            Close(null);
        }

        public void Initialize(IEnumerable<VisitorCard> cards)
        {
            Cards = cards;
        }
    }
}