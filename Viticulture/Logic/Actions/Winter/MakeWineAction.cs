using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;
using Viticulture.Logic.State;
using Viticulture.Screens.Game.Actions.Winter.MakeWine;
using Viticulture.Services;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(MakeWineAction))]
    public class MakeWineAction : BonusAction, IWinterAction
    {
        private readonly IMetroDialog _metroDialog;
        private readonly IMefContainer _mefContainer;
        public override string Text => "Make up to 2 wine tokens";
        public override bool CanExecuteSpecial => GameState.Grapes.Any();
        public override string BonusText => "+1 wine";
        public bool IgnoreCellarRestriction { get; set; }
        public int MinimumValue { get; set; }

        [ImportingConstructor]
        public MakeWineAction(IEventAggregator eventAggregator, IMetroDialog metroDialog, IMefContainer mefContainer) : base(eventAggregator)
        {
            _metroDialog = metroDialog;
            _mefContainer = mefContainer;
        }

        public override async Task<bool> OnExecute()
        {
            var success = await MakeWine();
            if (!success)
            {
                MinimumValue = 1;
                IgnoreCellarRestriction = false;
                return false;
            }
            success = await MakeWine();
            if (!success)
            {
                MinimumValue = 1;
                IgnoreCellarRestriction = false;
                return await _metroDialog.DoneOrCancelVisitor("making wine");
            }

            MinimumValue = 1;
            IgnoreCellarRestriction = false;
            return true;
        }

        public override async Task<bool> OnExecuteBonus()
        {
            var success = await MakeWine();
            if (!success) return await _metroDialog.DoneOrCancelVisitor("making wine");

            return true;
        }

        public async Task<bool> MakeWine()
        {
            var dialogViewModel = _mefContainer.GetExportedValue<IGrapesSelectionViewModel>();
            var selectedGrapes = (await _metroDialog.ShowDialog(dialogViewModel)).ToList();
            if (!selectedGrapes.Any()) return false;

            int value = selectedGrapes.Sum(p => p.Value);
            WineType type;
            if (selectedGrapes.Count == 1) type = selectedGrapes.First().GrapeColor == GrapeColor.Red ? WineType.Red : WineType.White;
            else if (selectedGrapes.Count == 2) type = WineType.Blush;
            else type = WineType.Sparkling;

            var firstAvailableSpotInCellar = GetFirstAvailableSpotInCellar(value, type);
            if (firstAvailableSpotInCellar == null)
            {
                await _metroDialog.ShowMessage("Make wine", "No room in cellar for selected wine or two low value");
                return false;
            }

            firstAvailableSpotInCellar.IsBought = true;
            selectedGrapes.ForEach(p => p.IsBought = false);
        
            return true;
        }

        private Wine GetFirstAvailableSpotInCellar(int value, WineType type)
        {
            if (type == WineType.Blush && !GameState.MediumCellar.IsBought) return null;
            if (type == WineType.Sparkling && !GameState.LargeCellar.IsBought) return null;

            if (!IgnoreCellarRestriction)
            {
                if (value > 3 && !GameState.MediumCellar.IsBought) value = 3;
                if (value > 6 && !GameState.LargeCellar.IsBought) value = 6;
            }

            if (value < MinimumValue) return null;

            return
                GameState.GetCellarByWineType(type)
                    .OrderByDescending(p => p.Value)
                    .FirstOrDefault(p => p.Value <= value && !p.IsBought);
        }
    }
}