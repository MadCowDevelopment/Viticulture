using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.FillOrder
{
    [Export(typeof(IWineSelectionViewModel))]
    public class WineSelectionViewModel : DialogViewModel<IEnumerable<Wine>>, IWineSelectionViewModel
    {
        private readonly IGameState _gameState;
        private OrderCard _orderToFill;

        [ImportingConstructor]
        public WineSelectionViewModel(IGameState gameState)
        {
            _gameState = gameState;
        }

        public IEnumerable<WineViewModel> Wines { get; private set; }

        public void Initialize(OrderCard orderToFill)
        {
            _orderToFill = orderToFill;
            Wines =
                _gameState.Wines.Where(
                    wine => orderToFill.RequiredWines.Any(r => r.Item1 == wine.Type && r.Item2 <= wine.Value))
                    .Select(p => new WineViewModel(p))
                    .ToList();
        }

        private IEnumerable<Wine> SelectedWines => Wines.Where(p => p.IsSelected).Select(p => p.Wine);

        public void Done()
        {
            Close(SelectedWines);
        }

        public bool CanDone()
        {
            return _orderToFill.WinesCanFillOrder(SelectedWines) &&
                   _orderToFill.RequiredWines.Count() == Wines.Count(p => p.IsSelected);
        }

        public void Cancel()
        {
            Close(null);
        }
    }
}