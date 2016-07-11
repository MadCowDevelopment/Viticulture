using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Viticulture.Logic.Actions
{
    public class UprootVineAction : PlayerAction
    {
        [ImportingConstructor]
        public UprootVineAction(IEventAggregator eventAggregator) : base(eventAggregator)
        {
        }

        public override string Text => "Uproot vine";
        public override bool CanExecuteSpecial => GameState.Fields.Any(p => p.Vines.Any());

        public override async Task<bool> OnExecute()
        {
            var selectedField = await PlayerSelection.Select("Select field", "Select field to uproot",
                GameState.Fields.Where(p => p.Vines.Any()));
            if (selectedField == null) return false;

            var selectedVine = await PlayerSelection.Select("Select vine", "Select vine to uproot", selectedField.Vines);
            if (selectedVine == null) return false;

            GameState.Hand.AddCard(selectedVine);
            selectedField.UprootVine(selectedVine);

            return true;
        }
    }
}