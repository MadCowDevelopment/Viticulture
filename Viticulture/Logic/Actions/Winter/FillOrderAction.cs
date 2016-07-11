using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Screens.Game.Actions.Winter.FillOrder;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(FillOrderAction))]
    public class FillOrderAction : BonusAction, IWinterAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Fill 1 order";
        public override bool CanExecuteSpecial => true;
        public override string BonusText => "+1 VP";

        [ImportingConstructor]
        public FillOrderAction(IEventAggregator eventAggregator, IMetroDialog metroDialog, IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public override async Task<bool> OnExecute()
        {
            var orderSelectionViewModel = _mefContainer.GetExportedValue<IOrderSelectionViewModel>();
            var selectedOrder = await _metroDialog.ShowDialog(orderSelectionViewModel);
            if (selectedOrder == null) return false;

            var wineSelectionViewModel = _mefContainer.GetExportedValue<IWineSelectionViewModel>();
            wineSelectionViewModel.Initialize(selectedOrder);
            var selectedWines = await _metroDialog.ShowDialog(wineSelectionViewModel);
            if (selectedWines == null) return false;

            foreach (var selectedWine in selectedWines)
            {
                selectedWine.IsBought = false;
            }

            GameState.VictoryPoints += selectedOrder.VictoryPoints;
            GameState.ResidualMoney += selectedOrder.Residual;

            return true;
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.VictoryPoints++;
            return Task.FromResult(true);
        }
    }
}