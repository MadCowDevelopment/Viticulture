using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Screens.Game.Actions.Winter.HarvestField;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(HarvestFieldAction))]
    public class HarvestFieldAction : BonusAction, IWinterAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Harvest 1 field";
        public override bool CanExecuteSpecial => GameState.Fields.Any(p => p.IsBought && p.Vines.Any());
        public override string BonusText => "+1 field";

        [ImportingConstructor]
        public HarvestFieldAction(IEventAggregator eventAggregator, IMetroDialog metroDialog, IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public override async Task<bool> OnExecute()
        {
            return await HarvestField();
        }

        private async Task<bool> HarvestField()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IFieldSelectionViewModel>();
            var selectedField = await _metroDialog.ShowDialog(dialogViewModel);
            if (selectedField == null) return false;

            AddToCrushpad(selectedField.RedVines, GameState.RedGrapes);
            AddToCrushpad(selectedField.WhiteVines, GameState.WhiteGrapes);

            return true;
        }

        private void AddToCrushpad(int vineValue, IEnumerable<Grape> grapes)
        {
            if (vineValue == 0) return;

            var firstFreeGrape =
                grapes.OrderByDescending(p => p.Value).FirstOrDefault(p => p.Value <= vineValue && !p.IsBought);
            if (firstFreeGrape == null) return;
            firstFreeGrape.IsBought = true;
        }

        protected override async Task<bool> OnExecuteBonus()
        {
            return await HarvestField();
        }
    }
}