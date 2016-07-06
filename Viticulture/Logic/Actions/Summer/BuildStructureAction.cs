using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Screens.Game.Actions.Summer.BuildStructure;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Summer
{
    [Export(typeof(BuildStructureAction))]
    public class BuildStructureAction : BonusAction, ISummerAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Build 1 structure";
        public override string BonusText => "+1 lira";

        [ImportingConstructor]
        public BuildStructureAction(IEventAggregator eventAggregator, IMetroDialog metroDialog, IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public int BuildingBonus { get; set; }

        public override async Task<bool> OnExecute()
        {
            return await SelectBuilding();
        }

        private async Task<bool> SelectBuilding()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IBuildStructureViewModel>();
            dialogViewModel.BuildingBonus = BuildingBonus;
            var selectedBuilding =  await _metroDialog.ShowDialog(dialogViewModel);
            if (selectedBuilding == null) return false;
            selectedBuilding.IsBought = true;
            GameState.Money -= Math.Max(selectedBuilding.Cost - BuildingBonus, 0);
            return true;
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.Money++;
            return Task.FromResult(true);
        }
    }
}