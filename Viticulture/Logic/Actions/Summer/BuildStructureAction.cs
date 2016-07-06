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

        public override async Task<bool> OnExecute()
        {
            await SelectBuilding();
            return true;
        }

        private async Task SelectBuilding()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IBuildStructureViewModel>();
            await _metroDialog.ShowDialog(dialogViewModel);
        }

        protected override void OnExecuteBonus()
        {
            GameState.Money++;
        }
    }
}