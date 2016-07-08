using System.Collections.Generic;
using Viticulture.Logic.Cards.Orders;
using Viticulture.Logic.Pieces;
using Viticulture.Services;

namespace Viticulture.Screens.Game.Actions.Winter.FillOrder
{
    public interface IWineSelectionViewModel : IDialogViewModel<IEnumerable<Wine>> {
        void Initialize(OrderCard orderToFill);
    }
}