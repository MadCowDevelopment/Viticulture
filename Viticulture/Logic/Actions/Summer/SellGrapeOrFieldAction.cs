using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Summer.SellGrapeOrField;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(SellGrapeOrFieldAction))]
    public class SellGrapeOrFieldAction : BonusAction, ISummerAction
    {
        private readonly IGameState _gameState;
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Sell grape(s) or buy/sell 1 field";

        public override bool CanExecuteSpecial
            => GameState.Fields.Any(p => p.IsBought) || GameState.Grapes.Any(p => p.IsBought);
        public override string BonusText => "+1 VP";

        [ImportingConstructor]
        public SellGrapeOrFieldAction(IEventAggregator eventAggregator, IGameState gameState, IMetroDialog metroDialog,
            IMefContainer mefContainer) : base(eventAggregator)
        {
            _gameState = gameState;
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public override async Task<bool> OnExecute()
        {
            var result = await _metroDialog.ShowMessage("Sell grape(s)/field", "Do you want to sell grape or buy/sell field?",
                MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings {AffirmativeButtonText = "grape", NegativeButtonText = "field"});
            return result == MessageDialogResult.Affirmative ? await SellGrape() : await BuyOrSellField();
        }

        private async Task<bool> SellGrape()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IGrapesSelectionViewModel>();
            var result = (await _metroDialog.ShowDialog(dialogViewModel)).ToList();
            if (result.Any())
            {
                foreach (var grape in result)
                {
                    _gameState.Money += grape.SellValue;
                    grape.IsBought = false;
                }

                return true;
            }

            return false;
        }

        private async Task<bool> BuyOrSellField()
        {
            var result = await _metroDialog.ShowMessage("Buy/sell field", "Do you want to buy or sell a field?",
                MessageDialogStyle.AffirmativeAndNegative,
                new MetroDialogSettings {AffirmativeButtonText = "buy", NegativeButtonText = "sell"});
            return result == MessageDialogResult.Affirmative ? await BuyField() : await SellField();
        }

        private async Task<bool> BuyField()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IBuyFieldSelectionViewModel>();
            var selectedField = await _metroDialog.ShowDialog(dialogViewModel);
            if (selectedField == null) return false;
            selectedField.IsBought = true;
            _gameState.Money -= selectedField.Value;
            return true;
        }

        private async Task<bool> SellField()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<ISellFieldSelectionViewModel>();
            var selectedField = await _metroDialog.ShowDialog(dialogViewModel);
            if (selectedField == null) return false;
            selectedField.IsBought = false;
            _gameState.Money += selectedField.Value;
            return true;
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.VictoryPoints++;
            return Task.FromResult(true);
        }
    }
}