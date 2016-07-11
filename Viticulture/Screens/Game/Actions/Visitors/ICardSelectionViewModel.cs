using System.Collections.Generic;
using Viticulture.Logic.Cards.Visitors;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Visitors
{
    public interface ICardSelectionViewModel : IDialogViewModel<VisitorCard> {
        IEnumerable<VisitorCard> Cards { get; }
        void Play(VisitorCard card);
        void Cancel();
        void Initialize(IEnumerable<VisitorCard> cards);
    }
}