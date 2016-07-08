using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.FillOrder
{
    [Export(typeof(IOrderSelectionViewModel))]
    public class OrderSelectionViewModel : DialogViewModel<OrderCard>, IOrderSelectionViewModel
    {
        private readonly IGameState _gameState;

        [ImportingConstructor]
        public OrderSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<OrderCard> Orders => _gameState.OrderDeck.Cards;

        public void Select(OrderCard card)
        {
            Close(card);
        }

        public bool CanSelect(OrderCard card)
        {
            return card.WinesCanFillOrder(_gameState.Wines);
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}