using System;
using System.ComponentModel.Composition;
using System.Linq;
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
        public override bool CanExecuteSpecial => GameState.Structures.Any(p => p.IsBought == false);

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
            return await SelectStructure();
        }

        private async Task<bool> SelectStructure()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IBuildStructureViewModel>();
            dialogViewModel.BuildingBonus = BuildingBonus;
            var selectedStructure =  await _metroDialog.ShowDialog(dialogViewModel);
            if (selectedStructure == null) return false;
            selectedStructure.IsBought = true;
            GameState.Money -= Math.Max(selectedStructure.Cost - BuildingBonus, 0);
            BuildingBonus = 0;
            return true;
        }

        protected override Task<bool> OnExecuteBonus()
        {
            GameState.Money++;
            return Task.FromResult(true);
        }
    }
}