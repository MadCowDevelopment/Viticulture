using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Viticulture.Logic.Pieces;

namespace Viticulture.Logic.Actions.Winter
{
    [Export(typeof(HarvestFieldAction))]
    public class HarvestFieldAction : BonusAction, IWinterAction
    {
        public override string Text => "Harvest 1 field";

        public override bool CanExecuteSpecial
            => GameState.Fields.Any(p => p.IsBought && p.Vines.Any() && !p.HasBeenUsed);

        public override string BonusText => "+1 field";

        [ImportingConstructor]
        public HarvestFieldAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override async Task<bool> OnExecute()
        {
            return await HarvestField();
        }

        private async Task<bool> HarvestField()
        {
            var selectedField =
                await
                    PlayerSelection.Select("Select field", "Choose a field to harvest",
                        GameState.Fields.Where(p => p.IsBought && p.Vines.Any() && !p.HasBeenUsed));
            if (selectedField == null) return false;

            selectedField.HasBeenUsed = true;
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

        public override async Task<bool> OnExecuteBonus()
        {
            return await HarvestField();
        }
    }
}