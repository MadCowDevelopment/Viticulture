using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

using Viticulture.Screens.Game.Actions.Summer.PlantVine;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(PlantVineAction))]
    public class PlantVineAction : BonusAction, ISummerAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Plant 1 vine";
        public override bool CanExecuteSpecial => GameState.Hand.Vines.Any();
        public override string BonusText => "+1 vine";

        [ImportingConstructor]
        public PlantVineAction(IEventAggregator eventAggregator, IMetroDialog metroDialog, IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public bool IgnoreRequirements { get; set; }
        public bool IgnoreMaxValue { get; set; }

        public override async Task<bool> OnExecute()
        {
            var vineSelectionViewModel = _mefContainer.GetExportedValue<IVineSelectionViewModel>();
            var selectedVine = await _metroDialog.ShowDialog(vineSelectionViewModel);
            if (selectedVine == null)
            {
                IgnoreMaxValue = false;
                IgnoreRequirements = false;
                return false;
            }

            var fieldSelectionViewModel = _mefContainer.GetExportedValue<IFieldSelectionViewModel>();
            fieldSelectionViewModel.IgnoreMaxValue = IgnoreMaxValue;
            fieldSelectionViewModel.VineToPlant = selectedVine;
            var selectedField = await _metroDialog.ShowDialog(fieldSelectionViewModel);
            if (selectedField == null)
            {
                IgnoreMaxValue = false;
                IgnoreRequirements = false;
                return false;
            }

            selectedField.PlantVine(selectedVine);
            GameState.Hand.RemoveCard(selectedVine);
            if (GameState.Windmill.IsBought && !GameState.Windmill.HasBeenUsed)
            {
                GameState.Windmill.HasBeenUsed = true;
                GameState.VictoryPoints++;
            }

            IgnoreMaxValue = false;
            IgnoreRequirements = false;
            return true;
        }

        public override async Task<bool> OnExecuteBonus()
        {
            var vineSelectionViewModel = _mefContainer.GetExportedValue<IVineSelectionViewModel>();
            var selectedVine = await _metroDialog.ShowDialog(vineSelectionViewModel);
            if (selectedVine == null) return false;

            var fieldSelectionViewModel = _mefContainer.GetExportedValue<IFieldSelectionViewModel>();
            fieldSelectionViewModel.VineToPlant = selectedVine;
            var selectedField = await _metroDialog.ShowDialog(fieldSelectionViewModel);
            if (selectedField == null) return false;

            selectedField.PlantVine(selectedVine);
            GameState.Hand.RemoveCard(selectedVine);

            return true;
        }
    }
}